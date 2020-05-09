<template>
  <v-row class="fill-height" dense>
    <v-col v-if="fullScreen">
      <v-container>
        <slot />
      </v-container>
    </v-col>
    <v-col v-else cols="12" sm="11" md="10" lg="9" xl="8" class="mx-auto">
      <slot />
    </v-col>
  </v-row>
</template>
<script lang="ts">
import Vue from "vue";

export default Vue.component("content-display", {
  props: {
    fullScreen: {
      type: Boolean,
      required: false
    }
  }
});
</script>