<template>
  <v-container>
    <v-skeleton-loader v-if="wager == null" type="card" />
    <v-row v-else dense>
      <v-col cols="12">
        <WagerDisplay :hasView="false" :game="game" :data="wager" />
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import WagerDisplay from "../components/WagerDisplay";
export default {
  components: {
    WagerDisplay
  },
  props: {
    game: {
      type: String,
      required: true
    },
    id: {
      required: true
    }
  },
  data() {
    return {
      wager: null
    };
  },
  methods: {
    async getWager() {
      this.$axios.get("/api/wagers/" + this.id).then(response => {
        console.log(response);
        this.wager = response.data;
      });
    }
  },
  async created() {
    await this.getWager();
  }
};
</script>
