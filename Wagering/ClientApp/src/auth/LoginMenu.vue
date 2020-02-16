<template>
  <div class="buttons">
    <div v-if="this.$store.state.account.isAuthenticated">
      <router-link
        :to="profile"
        class="button is-dark"
      >Hello {{ this.$store.state.account.username }}</router-link>
      <router-link :to="logout" class="button is-dark">Logout</router-link>
    </div>
    <div v-else>
      <router-link :to="register" class="button is-dark">Register</router-link>
      <router-link :to="login" class="button is-dark">Login</router-link>
    </div>
  </div>
</template>
<script>
import { ApplicationPaths } from "./AuthConstants";
export default {
  name: "LoginMenu",
  data() {
    return {
      profile: ApplicationPaths.Profile,
      logout: ApplicationPaths.LogOut,
      register: ApplicationPaths.Register,
      login: ApplicationPaths.Login
    };
  }
};
</script>