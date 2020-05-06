<template>
  <v-tabs grow show-arrows color="secondary">
    <!--Member invitations sent here and confirm send is shown when available-->
    <v-tab>Pending</v-tab>
    <!--Item is sent here for other party to accept-->
    <v-tab>Sent</v-tab>
    <!--Item is confirmed and button here to vote for winner/report-->
    <v-tab>Confirmed</v-tab>
    <!--Results view-->
    <v-tab>Completed</v-tab>
    <v-tab-item>
      <v-container></v-container>
    </v-tab-item>
    <v-tab-item>
      <v-container></v-container>
    </v-tab-item>
    <v-tab-item>
      <v-container></v-container>
    </v-tab-item>
    <v-tab-item>
      <v-container></v-container>
    </v-tab-item>
  </v-tabs>
</template>
<script lang="ts">
import Vue from "vue";
export default Vue.extend({});
</script>
