<template>
  <v-container>
    <!--Might need to split in host and request-->
    <!--Split into wagers/tournaments/leagues-->
    <v-container>
      <h1 class="text-center">Client Panel</h1>
    </v-container>
    <v-tabs grow optional show-arrows :value="selected">
      <v-tab>Wagers</v-tab>
      <v-tab>Tournaments</v-tab>
      <v-tab>Leagues</v-tab>
      <v-tab-item>
        <Wagers />
      </v-tab-item>
      <v-tab-item>
        <Tournaments />
      </v-tab-item>
      <v-tab-item>
        <Leagues />
      </v-tab-item>
    </v-tabs>
  </v-container>
</template>
<script>
import Wagers from "@/views/control/client/Wagers";
import Tournaments from "@/views/control/client/Tournaments";
import Leagues from "@/views/control/client/Leagues";
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
<style>
.v-tabs-bar.v-slide-group--is-overflowing.v-tabs-bar--is-mobile:not(.v-tabs-bar--show-arrows):not(.v-slide-group--has-affixes)
  .v-slide-group__prev {
  display: none !important;
}
</style>