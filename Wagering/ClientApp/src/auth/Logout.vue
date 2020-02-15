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
  mounted() {
    const action = this.props.action;
    switch (action) {
      case LogoutActions.Logout:
        if (!!window.history.state.state.local) {
          this.logout(this.getReturnUrl());
        } else {
          // This prevents regular links to <app>/authentication/logout from triggering a logout
          isReady = true;
          message = "The logout was not initiated from within the page.";
        }
        break;
      case LogoutActions.LogoutCallback:
        this.processLogoutCallback();
        break;
      case LogoutActions.LoggedOut:
        isReady = true;
        message = "You successfully logged out!";
        break;
      default:
        throw new Error(`Invalid action '${action}'`);
    }
    this.populateAuthenticationState();
  },
  props: {
    action: String
  },
  data: {
    message: String,
    isReady: Boolean,
    authenticated: Boolean
  },
  methods: {
    logout: async returnUrl => {
      const state = { returnUrl };
      const isauthenticated = await AuthService.isAuthenticated();
      if (isauthenticated) {
        const result = await AuthService.signOut(state);
        switch (result.status) {
          case AuthenticationResultStatus.Redirect:
            break;
          case AuthenticationResultStatus.Success:
            removeUser();
            await this.navigateToReturnUrl(returnUrl);
            break;
          case AuthenticationResultStatus.Fail:
            message = result.message;
            break;
          default:
            throw new Error("Invalid authentication result status.");
        }
      } else {
        message = "You successfully logged out!";
      }
    },
    processLogoutCallback: async () => {
      const url = window.location.href;
      const result = await AuthService.completeSignOut(url);
      switch (result.status) {
        case AuthenticationResultStatus.Redirect:
          // There should not be any redirects as the only time completeAuthentication finishes
          // is when we are doing a redirect sign in flow.
          throw new Error("Should not redirect.");
        case AuthenticationResultStatus.Success:
          removeUser();
          await this.navigateToReturnUrl(this.getReturnUrl(result.state));
          break;
        case AuthenticationResultStatus.Fail:
          message = result.message;
          break;
        default:
          throw new Error("Invalid authentication result status.");
      }
    },
    removeUser: function() {
      this.$store.dispatch("setLogout");
    },
    populateAuthenticationState: async () => {
      const result = await AuthService.isAuthenticated();
      isReady = true;
      authenticated = result;
    },
    getReturnUrl: function(state) {
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
    navigateToReturnUrl: function(returnUrl) {
      // It's important that we do a replace here so that we remove the callback uri with the
      // fragment containing the tokens from the browser history.
      window.location.replace(returnUrl);
    }
  }
};
</script>
