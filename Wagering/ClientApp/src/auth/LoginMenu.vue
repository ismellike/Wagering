<template>
  <div>
    <h1>Helloo</h1>
    <div v-if="this.$store.state.account.isAuthenticated">
      <router-link :to="ApplicationPaths.Profile">Hello {{ this.$store.state.account.username }}</router-link>
      <router-link :to="ApplicationPaths.LogOut">Logout</router-link>
    </div>
    <div v-else>
      <router-link :to="ApplicationPaths.Register">Register</router-link>
      <router-link :to="ApplicationPaths.Login">Login</router-link>
    </div>
  </div>
</template>
<script>
import { ApplicationPaths } from "./AuthConstants";
export default {
  name: "LoginMenu"
};
</script>
