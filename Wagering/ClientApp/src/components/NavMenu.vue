<template>
  <nav class="navbar is-primary is-fixed-top" role="navigation" aria-label="main navigation">
    <div class="navbar-brand">
      <router-link class="navbar-item" to="/">Wagering.gg</router-link>

      <a role="button" class="navbar-burger burger" aria-label="menu" v-on:click="toggleActive">
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
      </a>
    </div>

    <div :class="shouldShow">
      <div class="navbar-start">
        <router-link class="navbar-item" to="/">Home</router-link>
        <router-link class="navbar-item" to="/about">About</router-link>
        <router-link class="navbar-item" to="/hub">The Hub</router-link>
      </div>

      <div class="navbar-end">
        <div class="navbar-item">
          <LoginMenu />
        </div>
      </div>
    </div>
  </nav>
</template>
<script>
import LoginMenu from "../auth/LoginMenu";
export default {
  data() {
    return {
      isActive: false
    };
  },
  components: {
    LoginMenu
  },
  methods: {
    toggleActive() {
      this.isActive = !this.isActive;
    }
  },
  computed: {
    shouldShow() {
      return this.isActive ? "navbar-menu is-active" : "navbar-menu";
    }
  }
};
</script>
<style scoped>
.navbar-brand {
  font-weight: bold;
}
</style>