<template>
  <div v-if="this.$store.state.account.isAuthenticated">
    <router-link :to="profile">Hello {{ this.$store.state.account.username }}</router-link>|
    <router-link :to="logout">Logout</router-link>
  </div>
  <div v-else>
    <router-link :to="register">Register</router-link>|
    <router-link :to="login">Login</router-link>
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