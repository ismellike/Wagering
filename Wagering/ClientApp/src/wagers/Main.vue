<template>
  <v-container>
    <h1 class="text-center">Wagers - {{query.page}}</h1>
    <v-bottom-sheet v-model="showFilter">
      <template v-slot:activator="{ on }">
        <v-btn color="green" dark v-on="on">Filter</v-btn>
      </template>
      <v-sheet class="text-center" height="200px">
        <v-btn class="mt-6" flat color="error" v-on:click="showFilter = !showFilter">close</v-btn>
        <div class="py-3">This is a bottom sheet using the persistent prop</div>
      </v-sheet>
    </v-bottom-sheet>
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
    }
  },
  data() {
    return {
      query: {
        username: null,
        game: this.game.toLowerCase(),
        page: 1,
        playerCount: null,
        showClosed: false,
        minimumWager: null,
        maximumWager: null
      },
      wagers: [],
      totalPages: 0,
      showFilter: false,
      isLocked: false,
      isLoading: true,
      errors: []
    };
  },
  methods: {
    async previous() {
      this.query.page--;
      window.scrollTo(0, 0);
      await this.getWagers();
    },
    async next() {
      this.query.page++;
      window.scrollTo(0, 0);
      await this.getWagers();
    },
    async getWagers() {
      this.isLocked = true;
      //api call here
      await this.$axios
        .post("/api/wagers/search", this.query)
        .then(response => {
          console.log(response);
          if (response.status == 200) {
            this.totalPages = response.data.totalPages;
            this.wagers = response.data.list.slice();
          } else {
            this.errors = response.data.slice();
          }
        });
      this.isLocked = false;
    }
  },
  async created() {
    await this.getWagers();
    this.isLoading = false;
  }
};
</script>