<template>
  <v-app id="app">
    <v-navigation-drawer
      v-model="drawer"
      color="grey darken-4"
      elevation="20"
      clipped
      app
      right
      dark
      height="100%"
    >
      <v-list dense>
        <v-list-item to="/" link>
          <v-list-item-action>
            <v-icon>mdi-home</v-icon>
          </v-list-item-action>

          <v-list-item-content>
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item to="/about" link>
          <v-list-item-action>
            <v-icon>mdi-information-outline</v-icon>
          </v-list-item-action>

          <v-list-item-content>
            <v-list-item-title>About</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/hub" link>
          <v-list-item-action>
            <v-icon>mdi-gamepad-variant</v-icon>
          </v-list-item-action>

          <v-list-item-content>
            <v-list-item-title>The Hub</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
      <template v-slot:append>
        <LoginMenu />
      </template>
    </v-navigation-drawer>

    <v-app-bar app color="deep-purple" elevation="25" dense clipped-right dark>
      <v-toolbar-title>Wagering.gg</v-toolbar-title>
      <v-spacer />
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
    </v-app-bar>

    <v-content>
      <v-container class="fill-height" fluid>
        <router-view />
      </v-container>
    </v-content>

    <v-footer elevation="15" absolute inset clipped-right app dark>
      <v-btn href="https://discord.gg/HmmVMs2" target="_blank" icon>
        <v-icon dense>mdi-discord</v-icon>
      </v-btn>
      <v-btn href="https://www.instagram.com/wagering.gg" target="_blank" icon>
        <v-icon dense>mdi-instagram</v-icon>
      </v-btn>
      <v-btn href="https://twitter.com/WageringGG" target="_blank" icon>
        <v-icon dense>mdi-twitter</v-icon>
      </v-btn>
      <v-spacer />
      2020 - Wagering.gg
    </v-footer>
  </v-app>
</template>

<script>
import LoginMenu from "./auth/LoginMenu";

export default {
  name: "App",
  props: {
    source: String
  },
  components: {
    LoginMenu
  },
  data: () => ({
    drawer: null
  }),
  created() {
    this.$vuetify.theme.dark = true;
  }
};
</script>
