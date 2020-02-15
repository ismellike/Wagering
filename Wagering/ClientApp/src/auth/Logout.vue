<template>
  <div v-if="!isReady" />
  <div v-else-if="!!message">{{ message }}</div>
  <div v-else>
    <div v-if="action === LogoutActions.Logout">Processing logout</div>
    <div v-else-if="action === LogoutActions.LogoutCallback">Processing login callback</div>
    <div v-else-if="action === LogoutActions.LoggedOut">{{ message }}</div>
    <div v-else>Invalid action {{ action }}</div>
  </div>
</template>
<script>
import AuthService from "./AuthService";
import { AuthenticationResultStatus } from "./AuthService";
import {
  QueryParameterNames,
  LogoutActions,
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
      message: undefined,
      isReady: false,
      authenticated: false
    };
  },
  mounted() {
    const action = this.action;
    switch (action) {
      case LogoutActions.Logout:
        this.logout(this.getReturnUrl());
        break;
      case LogoutActions.LogoutCallback:
        this.processLogoutCallback();
        break;
      case LogoutActions.LoggedOut:
        this.isReady = true;
        this.message = "You successfully logged out!";
        break;
      default:
        throw new Error(`Invalid action '${action}'`);
    }
    this.populateAuthenticationState();
  },
  methods: {
    async logout(returnUrl) {
      const state = { returnUrl };
      const isauthenticated = await AuthService.isAuthenticated();
      if (isauthenticated) {
        const result = await AuthService.signOut(state);
        switch (result.status) {
          case AuthenticationResultStatus.Redirect:
            break;
          case AuthenticationResultStatus.Success:
            this.removeUser();
            await this.navigateToReturnUrl(returnUrl);
            break;
          case AuthenticationResultStatus.Fail:
            this.message = result.message;
            break;
          default:
            throw new Error("Invalid authentication result status.");
        }
      } else {
        this.removeUser();
        this.message = "You successfully logged out!";
      }
    },
    async processLogoutCallback() {
      const url = window.location.href;
      const result = await AuthService.completeSignOut(url);
      switch (result.status) {
        case AuthenticationResultStatus.Redirect:
          // There should not be any redirects as the only time completeAuthentication finishes
          // is when we are doing a redirect sign in flow.
          throw new Error("Should not redirect.");
        case AuthenticationResultStatus.Success:
          this.removeUser();
          await this.navigateToReturnUrl(this.getReturnUrl(result.state));
          break;
        case AuthenticationResultStatus.Fail:
          this.message = result.message;
          break;
        default:
          throw new Error("Invalid authentication result status.");
      }
    },
    removeUser() {
      this.$store.dispatch("setLogout");
    },
    async populateAuthenticationState() {
      const result = await AuthService.isAuthenticated();
      this.isReady = true;
      this.authenticated = result;
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
