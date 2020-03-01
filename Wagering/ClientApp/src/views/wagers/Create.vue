<template>
  <v-container></v-container>
</template>
<script>
import { ValidationObserver } from "vee-validate";
export default {
  data() {
    return {
      wager: {
        minimumAmount: null,
        maximumAmount: null,
        description: null
      }
    };
  },
  methods: {
    postWager() {}
  }
};
</script>