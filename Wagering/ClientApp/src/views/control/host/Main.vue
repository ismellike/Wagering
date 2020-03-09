<template>
  <v-container>
    <!--Need to change from tabs to nav bar-->
    <!--Split into wagers/tournaments/leagues-->
    <v-container>
      <h1 class="text-center">Host Panel</h1>
    </v-container>
    <v-tabs grow optional :value="selected">
      <v-tab>Wagers</v-tab>
      <v-tab>Tournaments</v-tab>
      <v-tab>Leagues</v-tab>
      <v-tab-item>
        <router-view />
      </v-tab-item>
    </v-tabs>
  </v-container>
</template>
<script>
import Wagers from "@/views/control/host/wagers/Main";
import Tournaments from "@/views/control/host/tournaments/Main";
import Leagues from "@/views/control/host/leagues/Main";
export default {
  components: {
    Wagers,
    Tournaments,
    Leagues
  },
  data() {
    return {
      loadedPage: null,
      selected: null
    };
  },
  methods: {
    change() {}
  },
  created() {
    if (this.$route.params.type != null) {
      switch (this.$route.params.type.toLowerCase()) {
        case "wagers":
          this.selected = 0;
          break;
        case "tournaments":
          this.selected = 1;
          break;
        case "leagues":
          this.selected = 2;
          break;
      }
    }
  }
};
</script>