<template>
  <v-container>
    <!--Split into wagers/tournaments/leagues-->
    <v-tabs grow optional @change="change">
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
import Wagers from "@/views/control/Wagers";
import Tournaments from "@/views/control/Tournaments";
import Leagues from "@/views/control/Leagues";
export default {
  components: {
    Wagers,
    Tournaments,
    Leagues
  },
  data() {
    return {
      loadedPage: null
    };
  },
  methods: {
    change(page) {
      if (page == undefined) return;
      if (this.loadedPage == page) return;
      this.loadedPage = page;

      //load data here
      switch (page) {
        //Wagers
        case 0:
          break;
        //Tournaments
        case 1:
          break;
        //Leagues
        case 2:
          break;
      }
    }
  }
};
</script>