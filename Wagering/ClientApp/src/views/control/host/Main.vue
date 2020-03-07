<template>
  <v-container>
    <!--Might need to split in host and request-->
    <!--Split into wagers/tournaments/leagues-->
    <v-container>
      <h1 class="text-center">Host Panel</h1>
    </v-container>
    <v-tabs grow optional :value="selected">
      <v-tab>Wagers</v-tab>
      <v-tab>Tournaments</v-tab>
      <v-tab>Leagues</v-tab>
      <v-tabs-items>
        <v-tab-item>
          <Wagers />
        </v-tab-item>
        <v-tab-item>
          <Tournaments />
        </v-tab-item>
        <v-tab-item>
          <Leagues />
        </v-tab-item>
      </v-tabs-items>
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