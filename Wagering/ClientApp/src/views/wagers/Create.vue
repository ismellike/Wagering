<template>
  <v-container></v-container>
</template>
<script>
import { ValidationObserver } from "vee-validate";
export default {
  data() {
    return {
      wager: {
        gameName: this.$route.params.game.toLowerCase(),
        minimumWager: null,
        maximumWager: null,
        description: null
      },
      errors: []
    };
  },
  methods: {
    postWager() {
      this.$axios.post("api/wagers", this.wager).then(response => {
        //send to wager view if successful or show corresponding server error messages
        if (response.status == 200) {
          this.$router.push({
            name: "wager_view",
            params: { game: this.wager.gameName, id: response.data }
          });
        } else {
        }
      });
    }
  }
};
</script>