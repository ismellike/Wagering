﻿<template>
    <v-container>
        <h1 v-if="!!message">{{ message }}</h1>
        <div v-else>
            <h1 v-if="action === logout">Processing logout</h1>
            <h1 v-else-if="action === callback">Processing logout callback</h1>
            <h1 v-else-if="action === loggedOut">{{ message }}</h1>
            <h1 v-else>Invalid action {{ action }}</h1>
        </div>
    </v-container>
</template>
<script>
    import AuthService, { AuthenticationResultStatus } from "@/services/authentication";
    import {
        QueryParameterNames,
        LogoutActions,
        ApplicationPaths
    } from "@/constants/authentication";

    export default {
        props: {
            action: {
                type: String,
                required: true
            }
        },
        data() {
            return {
                message: undefined,
                logout: LogoutActions.Logout,
                callback: LogoutActions.LogoutCallback,
                loggedOut: LogoutActions.LoggedOut
            };
        },
        mounted() {
            const action = this.action;
            switch (action) {
                case LogoutActions.Logout:
                    this.processLogout(this.getReturnUrl());
                    break;
                case LogoutActions.LogoutCallback:
                    this.processLogoutCallback();
                    break;
                case LogoutActions.LoggedOut:
                    this.message = "You successfully logged out!";
                    break;
                default:
                    throw new Error(`Invalid action '${action}'`);
            }
        },
        methods: {
            processLogout(returnUrl) {
                const state = { returnUrl };
                AuthService.isAuthenticated().then(isAuthenticated => {
                    if (isAuthenticated) {
                        AuthService.signOut(state).then(result => {
                            switch (result.status) {
                                case AuthenticationResultStatus.Redirect:
                                    break;
                                case AuthenticationResultStatus.Success:
                                    this.removeUser();
                                    this.navigateToReturnUrl(returnUrl);
                                    break;
                                case AuthenticationResultStatus.Fail:
                                    this.message = result.message;
                                    break;
                                default:
                                    throw new Error("Invalid authentication result status.");
                            }
                        });
                    } else {
                        this.removeUser();
                        this.message = "You successfully logged out!";
                    }
                });
            },
            processLogoutCallback() {
                const url = window.location.href;
                AuthService.completeSignOut(url).then(result => {
                    switch (result.status) {
                        case AuthenticationResultStatus.Redirect:
                            // There should not be any redirects as the only time completeAuthentication finishes
                            // is when we are doing a redirect sign in flow.
                            throw new Error("Should not redirect.");
                        case AuthenticationResultStatus.Success:
                            this.removeUser();
                            this.navigateToReturnUrl(this.getReturnUrl(result.state));
                            break;
                        case AuthenticationResultStatus.Fail:
                            this.message = result.message;
                            break;
                        default:
                            throw new Error("Invalid authentication result status.");
                    }
                });
            },
            removeUser() {
                this.$store.dispatch("setLogout");
            },
            getReturnUrl(state) {
                const params = new URLSearchParams(window.location.search);
                const fromQuery = params.get(QueryParameterNames.ReturnUrl);
                if (fromQuery && !fromQuery.startsWith(`${window.location.origin}/`)) {
                    // This is an extra check to prevent open redirects.
                    throw new Error(
                        "Invalid return url. The return url needs to have the same origin as the current page."
                    );
                }
                return (
                    (state && state.returnUrl) ||
                    fromQuery ||
                    `${window.location.origin}${ApplicationPaths.LoggedOut}`
                );
            },
            navigateToReturnUrl(returnUrl) {
                // It's important that we do a replace here so that we remove the callback uri with the
                // fragment containing the tokens from the browser history.
                window.location.replace(returnUrl);
            }
        }
    };
</script>