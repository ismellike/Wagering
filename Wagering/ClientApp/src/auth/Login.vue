<template>
  <div v-if="!!message">{{ message }}</div>
  <div v-else>
    <div v-if="action === LoginActions.Login">Processing login</div>
    <div v-else-if="action === LoginActions.LoginCallback">Processing login callback</div>
    <div v-else-if="action === LoginActions.Profile || action === LoginActions.Register" />
    <div v-else>Invalid action {{ action }}</div>
  </div>
</template>
<script>
import AuthService from "./AuthService";
import { AuthenticationResultStatus } from "./AuthService";
import {
  LoginActions,
  QueryParameterNames,
  ApplicationPaths
} from "./AuthConstants";

export default {
  props: {
    action: {
      type: String,
      required: true
    }
  },
  data() {
    return {
      message: undefined
    };
  },
  mounted() {
    const action = this.action;
    switch (action) {
      case LoginActions.Login:
        this.login(this.getReturnUrl());
        break;
      case LoginActions.LoginCallback:
        this.processLoginCallback();
        break;
      case LoginActions.LoginFailed:
        const params = new URLSearchParams(window.location.search);
        const error = params.get(QueryParameterNames.Message);
        this.message = error;
        break;
      case LoginActions.Profile:
        this.redirectToProfile();
        break;
      case LoginActions.Register:
        this.redirectToRegister();
        break;
      default:
        throw new Error(`Invalid action '${action}'`);
    }
  },
  methods: {
    async login(returnUrl) {
      const state = { returnUrl };
      const result = await AuthService.signIn(state);
      switch (result.status) {
        case AuthenticationResultStatus.Redirect:
          break;
        case AuthenticationResultStatus.Success:
          await this.addUser();
          await this.navigateToReturnUrl(returnUrl);
          break;
        case AuthenticationResultStatus.Fail:
          this.message = result.message;
          break;
        default:
          throw new Error(`Invalid status result ${result.status}.`);
      }
    },
    async processLoginCallback() {
      const url = window.location.href;
      const result = await AuthService.completeSignIn(url);
      switch (result.status) {
        case AuthenticationResultStatus.Redirect:
          // There should not be any redirects as the only time completeSignIn finishes
          // is when we are doing a redirect sign in flow.
          throw new Error("Should not redirect.");
        case AuthenticationResultStatus.Success:
          await this.addUser();
          await this.navigateToReturnUrl(this.getReturnUrl(result.state));
          break;
        case AuthenticationResultStatus.Fail:
          this.message = result.message;
          break;
        default:
          throw new Error(
            `Invalid authentication result status '${result.status}'.`
          );
      }
    },
    async addUser() {
      const user = await AuthService.getUser();
      if (user && user.name != undefined)
        this.$store.dispatch("setLogin", user && user.name);
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
