<template>
  <v-container>
    <h1 class="text-center">Wagers | Page {{ query.page }}</h1>
    <v-bottom-sheet v-model="showFilter">
      <template v-slot:activator="{ on }">
        <v-btn color="green" dark v-on="on">Filter</v-btn>
      </template>
      <v-sheet class="text-center" height="200px">
        <ValidationObserver ref="observer" v-slot="{ validate, reset }">
          <div class="mt-6">
            <v-btn color="green" v-on:click="onMutate">Search</v-btn>
            <v-btn color="red" v-on:click="clear">Clear</v-btn>
          </div>
          <v-row>
            <v-col cols="12" sm="6" md="3">
              <!-- Validate for spaces -->
              <v-text-field v-model="form.username" label="Username"></v-text-field>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field v-model="form.playerCount" label="Player Count" type="number"></v-text-field>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <!-- Add the custom validation -->
              <v-text-field v-model="form.minimumWager" label="Minimum Wager" type="number"></v-text-field>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field v-model="form.maximumWager" label="Maximum Wager" type="number"></v-text-field>
            </v-col>
          </v-row>
        </ValidationObserver>
      </v-sheet>
    </v-bottom-sheet>
    <div v-if="isLoading">
      <v-skeleton-loader v-for="i in 15" :key="i" type="card" class="my-2" />
    </div>
    <v-row v-else dense>
      <v-col v-for="wager in wagers" :key="wager.id" cols="12">
        <WagerDisplay :data="wager" :game="query.game" class="my-2" />
      </v-col>
      <v-col class="text-center" cols="12">
        <v-pagination v-mutate="onMutate" v-model="query.page" :length="totalPages"></v-pagination>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import WagerDisplay from "../components/WagerDisplay";
import { ValidationObserver, ValidationProvider } from "vee-validate";

export default {
  components: {
    WagerDisplay,
    ValidationObserver,
    ValidationProvider
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
      form: {
        username: null,
        playerCount: null,
        showClosed: false,
        minimumWager: null,
        maximumWager: null
      },
      wagers: [],
      totalPages: 0,
      showFilter: false,
      isLoading: true,
      errors: []
    };
  },
  methods: {
    async onMutate() {
      this.$vuetify.goTo(0);
      await this.getWagers();
    },
    async getWagers() {
      //api call here
      await this.$axios
        .post("/api/wagers/search", this.query)
        .then(response => {
          console.log(response);
          if (response.status == 200) {
            this.totalPages = response.data.totalPages;
            this.wagers = response.data.list.slice();
            this.errors = [];
          } else {
            this.errors = response.data.slice();
          }
        });
    },
    async clear() {
      this.form.username = null;
      this.form.playerCount = null;
      this.form.showClosed = false;
      this.form.minimumWager = null;
      this.form.maximumWager = null;
      this.$refs.observer.reset();
      this.setFormVars();
      if (this.query.page == 1) await this.onMutate();
      else this.query.page = 1; //will get checked by mutate if changed
    },
    async submit() {
      this.$refs.observer.validate();
      this.setFormVars();
      if (this.query.page == 1) await this.onMutate();
      else this.query.page = 1; //will get checked by mutate if changed
    },
    setFormVars() {
      this.query.username = this.form.username;
      this.query.playerCount = this.form.playerCount;
      this.query.showClosed = this.form.showClosed;
      this.query.minimumWager = this.form.minimumWager;
      this.query.maximumWager = this.form.maximumWager;
    }
  },
  async created() {
    await this.getWagers();
    this.isLoading = false;
  }
};
</script>
