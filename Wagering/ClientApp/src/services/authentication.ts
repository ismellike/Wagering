import { UserManager, WebStorageStateStore, User } from "oidc-client";
import { ApplicationPaths, ApplicationName } from "../constants/authentication";
import store from "@/store";

export enum AuthenticationResultStatus {
    Redirect = "redirect",
    Success = "success",
    Fail = "fail",
}

export interface Result {
    status: AuthenticationResultStatus;
    message?: string;
    state?: State;
}

export interface State {
    returnUrl: string;
}

export class AuthorizeService {
    _user: User | null = null;
    _isAuthenticated: boolean = false;
    userManager: UserManager | null = null;

    // By default pop ups are disabled because they don't work properly on Edge.
    // If you want to enable pop up authentication simply set this flag to false.
    _popUpDisabled = true;

    async isAuthenticated() {
        const user = await this.getUser();
        return !!user;
    }

    async getUser() {
        if (this._user && this._user.profile) {
            return this._user.profile;
        }

        await this.ensureUserManagerInitialized();
        const user = await this.userManager?.getUser();
        return user && user.profile;
    }

    async getAccessToken() {
        await this.ensureUserManagerInitialized();
        const user = await this.userManager?.getUser();
        return user && user.access_token;
    }

    // We try to authenticate the user in three different ways:
    // 1) We try to see if we can authenticate the user silently. This happens
    //    when the user is already logged in on the IdP and is done using a hidden iframe
    //    on the client.
    // 2) We try to authenticate the user using a PopUp Window. This might fail if there is a
    //    Pop-Up blocker or the user has disabled PopUps.
    // 3) If the two methods above fail, we redirect the browser to the IdP to perform a traditional
    //    redirect flow.
    async signIn(state: State) {
        await this.ensureUserManagerInitialized();
        try {
            const silentUser = await this.userManager?.signinSilent(
                this.createArguments(null)
            );
            if (!silentUser) throw new Error("Undefined silent user.");
            this.updateState(silentUser);
            return this.success(state);
        } catch (silentError) {
            // User might not be authenticated, fallback to popup authentication
            console.log("Silent authentication error: ", silentError);

            try {
                if (this._popUpDisabled) {
                    throw new Error(
                        "Popup disabled. Change 'AuthorizeService.js:AuthorizeService._popupDisabled' to false to enable it."
                    );
                }

                const popUpUser = await this.userManager?.signinPopup(
                    this.createArguments(null)
                );
                if (!popUpUser) throw new Error("Undefined popup user.");
                this.updateState(popUpUser);
                return this.success(state);
            } catch (popUpError) {
                if (popUpError.message === "Popup window closed") {
                    // The user explicitly cancelled the login action by closing an opened popup.
                    return this.error("The user closed the window.");
                } else if (!this._popUpDisabled) {
                    console.log("Popup authentication error: ", popUpError);
                }

                // PopUps might be blocked by the user, fallback to redirect
                try {
                    await this.userManager?.signinRedirect(
                        this.createArguments(state)
                    );
                    return this.redirect();
                } catch (redirectError) {
                    console.log(
                        "Redirect authentication error: ",
                        redirectError
                    );
                    return this.error(redirectError);
                }
            }
        }
    }

    async completeSignIn(url: string) {
        try {
            await this.ensureUserManagerInitialized();
            const user = await this.userManager?.signinCallback(url);
            if (user) this.updateState(user);
            return this.success(user && user.state);
        } catch (error) {
            console.log("There was an error signing in: ", error);
            return this.error("There was an error signing in.");
        }
    }

    // We try to sign out the user in two different ways:
    // 1) We try to do a sign-out using a PopUp Window. This might fail if there is a
    //    Pop-Up blocker or the user has disabled PopUps.
    // 2) If the method above fails, we redirect the browser to the IdP to perform a traditional
    //    post logout redirect flow.
    async signOut(state: State) {
        await this.ensureUserManagerInitialized();
        try {
            if (this._popUpDisabled) {
                throw new Error(
                    "Popup disabled. Change 'AuthorizeService.js:AuthorizeService._popupDisabled' to false to enable it."
                );
            }

            await this.userManager?.signoutPopup(this.createArguments(null));
            this.updateState(null);
            return this.success(state);
        } catch (popupSignOutError) {
            console.log("Popup signout error: ", popupSignOutError);
            try {
                await this.userManager?.signoutRedirect(
                    this.createArguments(state)
                );
                return this.redirect();
            } catch (redirectSignOutError) {
                console.log("Redirect signout error: ", redirectSignOutError);
                return this.error(redirectSignOutError);
            }
        }
    }

    async completeSignOut(url: string) {
        await this.ensureUserManagerInitialized();
        try {
            const response = await this.userManager?.signoutCallback(url);
            this.updateState(null);
            return this.success(response && response.state);
        } catch (error) {
            console.log(`There was an error trying to log out '${error}'.`);
            return this.error(error);
        }
    }

    updateState(user: User | null) {
        if (user) {
            store.dispatch("setLogin", {
                id: user.profile.sub,
                displayName: user.profile.display_name,
                token: user.access_token,
            });
        } else {
            store.dispatch("setLogout");
        }
        this._user = user;
        this._isAuthenticated = !!this._user;
    }

    createArguments(state: State | null) {
        return {
            useReplaceToNavigate: true,
            data: state,
        };
    }

    error(message: string): Result {
        return {
            status: AuthenticationResultStatus.Fail,
            message: message,
        };
    }

    success(state: State): Result {
        return {
            status: AuthenticationResultStatus.Success,
            state,
        };
    }

    redirect(): Result {
        return {
            status: AuthenticationResultStatus.Redirect,
        };
    }

    async ensureUserManagerInitialized() {
        if (this.userManager !== null) {
            return;
        }

        const response = await fetch(
            ApplicationPaths.ApiAuthorizationClientConfigurationUrl
        );
        if (!response.ok) {
            throw new Error(`Could not load settings for '${ApplicationName}'`);
        }

        const settings = await response.json();
        settings.automaticSilentRenew = true;
        settings.includeIdTokenInSilentRenew = true;
        settings.userStore = new WebStorageStateStore({
            prefix: ApplicationName,
        });

        this.userManager = new UserManager(settings);

        this.userManager.events.addUserSignedOut(async () => {
            await this.userManager?.removeUser();
            this.updateState(null);
        });
    }

    static get instance() {
        return this;
    }
}

const AuthService = new AuthorizeService();

export default AuthService;
