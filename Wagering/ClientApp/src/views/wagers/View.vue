<template>
  <v-container>
    <v-skeleton-loader v-if="wager == null" type="card" />
    <div v-else>
      <v-row dense>
        <v-col cols="12">
          <WagerDisplay :hasView="false" :game="game" :data="wager" />
        </v-col>
      </v-row>
      <v-container>
        <v-expansion-panels v-if="!isHost" focusable>
          <v-expansion-panel>
            <v-expansion-panel-header class="title">Apply</v-expansion-panel-header>
            <v-expansion-panel-content v-if="this.$store.state.account.isAuthenticated">
              <v-container></v-container>
              <!--Apply logic here-->
            </v-expansion-panel-content>
            <v-expansion-panel-content v-else>
              <v-container>Sign in to apply for a wager.</v-container>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </v-container>
      <v-row dense>
        <v-col cols="12" sm="6" v-for="challenge in wager.challenges" :key="challenge.id">
          <ChallengeDisplay :data="challenge" />
        </v-col>
      </v-row>
    </div>
  </v-container>
</template>
<script>
import WagerDisplay from "@/components/WagerDisplay";
import ChallengeDisplay from "@/components/ChallengeDisplay";
export default {
  components: {
    WagerDisplay,
    ChallengeDisplay
  },
  data() {
    return {
      wager: null,
      id: this.$route.params.id,
      game: this.$route.params.game,
      isHost: false
    };
  },
  methods: {
    getWager() {
      this.$axios.get("/api/wagers/" + this.id).then(response => {
        console.log(response);
        this.wager = response.data;
        //check if user is part of hosts
      });
    }
  },
  created() {
    this.getWager();
  }
};
</script>
