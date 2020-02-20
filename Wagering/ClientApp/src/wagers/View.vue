<template>
  <v-container>
    <v-skeleton-loader v-if="wager == null" type="card" />
    <v-row v-else dense>
      <v-col cols="12">
        <WagerDisplay :hasView="false" :game="game" :data="wager" />
      </v-col>
    </v-row>
    <ChallengeDisplay v-for="challenge in wager.challenges" :data="challenge" :key="challenge.id" />
  </v-container>
</template>
<script>
import WagerDisplay from "../components/WagerDisplay";
import ChallengeDisplay from "../components/ChallengeDisplay";
export default {
  components: {
    WagerDisplay,
    ChallengeDisplay
  },
  data() {
    return {
      wager: null,
      id: this.$route.params.id,
      game: this.$route.params.game
    };
  },
  methods: {
    getWager() {
      this.$axios.get("/api/wagers/" + this.id).then(response => {
        console.log(response);
        this.wager = response.data;
      });
    }
  },
  created() {
    this.getWager();
  }
};
</script>
