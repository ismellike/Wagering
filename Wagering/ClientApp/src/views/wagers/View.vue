<template>
  <v-container>
    <v-container>
      <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
        <wager-display :wager="wager">
          <template v-if="!isHost && $store.getters.isAuthenticated" v-slot:button>
            <v-btn
              color="secondary"
              :to="{ name: 'wager_apply', params: { id: wager.id, game: $route.params.game }}"
            >Apply</v-btn>
          </template>
        </wager-display>
      </v-skeleton-loader>
    </v-container>
    <v-container>
      <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
        <v-card>
          <v-card-title>Challenges</v-card-title>
          <v-card-text>
            <template v-if="wager.challenges && wager.challenges.length > 0">
              <v-container v-for="challenge in wager.challenges" v-bind:key="challenge.id">
                <challenge-display :challenge="challenge" />
              </v-container>
            </template>
            <template v-else>There's currently no challenges.</template>
          </v-card-text>
        </v-card>
      </v-skeleton-loader>
    </v-container>
  </v-container>
</template>
<script lang="ts">
import Vue from "vue";
import WagerDisplay from "@/components/Wager/WagerDisplay.vue";
import ChallengeDisplay from "@/components/Wager/ChallengeDisplay.vue";

export default Vue.extend({
  components: {
    "wager-display": WagerDisplay,
    "challenge-display": ChallengeDisplay
  },
  data() {
    return {
      wager: {} as Wager,
      id: Number(this.$route.params.id) as number,
      game: this.$route.params.game as string,
      loading: true as boolean
    };
  },
  methods: {
    getWager(): void {
      this.$axios.get("/api/wager/" + this.id).then(response => {
        this.wager = response.data;
        this.loading = false;
      });
    }
  },
  computed: {
    isHost(): boolean {
      if (!this.$store.getters.isAuthenticated) return false;
      if (this.wager == null || this.wager.hosts == null) return false;
      return this.wager.hosts.some(
        (x: WagerHostBid) => x.userId == this.$store.getters.id
      );
    }
  },
  created() {
    this.getWager();
  }
});
</script>
