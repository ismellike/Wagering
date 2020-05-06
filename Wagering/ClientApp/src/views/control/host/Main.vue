<template>
  <content-display>
    <!--Need to change from tabs to nav bar-->
    <!--Split into wagers/tournaments/leagues-->
    <v-container>
      <h1 class="text-center">Host Panel</h1>
    </v-container>
    <v-tabs grow show-arrows optional color="secondary">
      <v-tab to="/host/wagers">Wagers</v-tab>
      <v-tab to="/host/tournaments">Tournaments</v-tab>
      <v-tab to="/host/leagues">Leagues</v-tab>
    </v-tabs>
    <router-view></router-view>
  </content-display>
</template>
<script lang="ts">
import Vue from "vue";

export default Vue.extend({});
</script>
