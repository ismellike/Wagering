<template>
  <div class="hero-body is-block">
    <div class="container">
      <Loading v-if="wager == null" />
      <div v-else>
        <WagerDisplay :hasView="false" :game="game" :data="wager" />
      </div>
    </div>
  </div>
</template>
<script>
import WagerDisplay from "../components/WagerDisplay";
import Loading from "../components/Loading";
export default {
  components: {
    WagerDisplay,
    Loading
  },
  props: {
    game: {
      type: String,
      required: true
    },
    id: {
      type: Number,
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