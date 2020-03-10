<template>
  <v-container fluid class="mb-auto">
    <!--Need to change from tabs to nav bar-->
    <!--Split into wagers/tournaments/leagues-->
    <v-container>
      <h1 class="text-center">Host Panel</h1>
    </v-container>
    <v-tabs grow optional>
      <v-tab to="/host-panel/wagers">Wagers</v-tab>
      <v-tab to="/host-panel/tournaments">Tournaments</v-tab>
      <v-tab to="/host-panel/leagues">Leagues</v-tab>
    </v-tabs>
    <router-view></router-view>
  </v-container>
</template>
<script>
export default {};
</script>