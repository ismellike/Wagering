<template>
  <content-display fullScreen>
    <h1 class="text-center display-1">Wagering.gg</h1>
    <h2 class="text-center headline">Invest in yourself: one game at a time.</h2>
    <v-row>
      <v-col cols="12" sm="4">
        <v-img src="@/assets/agreement.jpg" aspect-ratio=".5625" />
      </v-col>
      <v-col cols="12" sm="4">
        <v-img src="@/assets/play.jpg" aspect-ratio=".5625" />
      </v-col>
      <v-col cols="12" sm="4">
        <v-img src="@/assets/peace.jpg" aspect-ratio=".5625" />
      </v-col>
    </v-row>
  </content-display>
</template>
<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  name: "Home"
});
</script>
