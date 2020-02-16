<template>
  <div id="app">
    <NavMenu />
    <section class="hero is-fullheight-with-navbar is-black">
      <router-view />
    </section>
    <Footer />
  </div>
</template>
<script>
import NavMenu from "./components/NavMenu";
import Footer from "./components/Footer";
export default {
  name: "app",
  components: {
    NavMenu,
    Footer
  }
};
</script>