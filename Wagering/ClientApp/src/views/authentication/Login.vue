<template>
  <v-container>
    <h1 v-if="!!message">{{ message }}</h1>
    <div v-else>
      <h1 v-if="action === login">Processing login</h1>
      <h1 v-else-if="action === callback">Processing login callback</h1>
      <h1 v-else-if="
        action === profile || action === register
      " />
      <h1 v-else>Invalid action {{ action }}</h1>
    </div>
  </v-container>
</template>
<script>
import AuthService, {
  AuthenticationResultStatus
} from "@/services/authentication";
import {
  LoginActions,
  QueryParameterNames,
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
      login: LoginActions.Login,
      callback: LoginActions.LoginCallback,
      profile: LoginActions.Profile,
      register: LoginActions.Register
    };
  },
  mounted() {
    switch (this.action) {
      case LoginActions.Login:
        this.processLogin(this.getReturnUrl());
        break;
      case LoginActions.LoginCallback:
        this.processLoginCallback();
        break;
      case LoginActions.LoginFailed: {
        const params = new URLSearchParams(window.location.search);
        const error = params.get(QueryParameterNames.Message);
        this.message = error;
        break;
      }
      case LoginActions.Profile:
        this.redirectToProfile();
        break;
      case LoginActions.Register:
        this.redirectToRegister();
        break;
      default:
        throw new Error(`Invalid action '${this.action}'`);
    }
  },
  methods: {
    processLogin(returnUrl) {
      const state = { returnUrl };
      AuthService.signIn(state).then(result => {
        switch (result.status) {
          case AuthenticationResultStatus.Redirect:
            break;
          case AuthenticationResultStatus.Success:
            this.navigateToReturnUrl(returnUrl);
            break;
          case AuthenticationResultStatus.Fail:
            this.message = result.message;
            break;
          default:
            throw new Error(`Invalid status result ${result.status}.`);
        }
      });
    },
    processLoginCallback() {
      const url = window.location.href;
      AuthService.completeSignIn(url).then(result => {
        switch (result.status) {
          case AuthenticationResultStatus.Redirect:
            // There should not be any redirects as the only time completeSignIn finishes
            // is when we are doing a redirect sign in flow.
            throw new Error("Should not redirect.");
          case AuthenticationResultStatus.Success:
            this.navigateToReturnUrl(this.getReturnUrl(result.state));
            break;
          case AuthenticationResultStatus.Fail:
            this.message = result.message;
            break;
          default:
            throw new Error(
              `Invalid authentication result status '${result.status}'.`
            );
        }
      });
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
        (state && state.returnUrl) || fromQuery || `${window.location.origin}/`
      );
    },
    redirectToRegister() {
      this.redirectToApiAuthorizationPath(
        `${ApplicationPaths.IdentityRegisterPath}?${
          QueryParameterNames.ReturnUrl
        }=${encodeURI(ApplicationPaths.Login)}`
      );
    },
    redirectToProfile() {
      this.redirectToApiAuthorizationPath(ApplicationPaths.IdentityManagePath);
    },
    redirectToApiAuthorizationPath(apiAuthorizationPath) {
      const redirectUrl = `${window.location.origin}${apiAuthorizationPath}`;
      // It's important that we do a replace here so that when the user hits the back arrow on the
      // browser he gets sent back to where it was on the app instead of to an endpoint on this
      // component.
      window.location.replace(redirectUrl);
    },
    navigateToReturnUrl(returnUrl) {
      // It's important that we do a replace here so that we remove the callback uri with the
      // fragment containing the tokens from the browser history.
      window.location.replace(returnUrl);
    }
  }
};
</script>