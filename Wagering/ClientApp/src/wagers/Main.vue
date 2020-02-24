<template>
  <v-container>
    <v-container>
      <h1 class="text-center">Wagers | Page {{ query.page }}</h1>
    </v-container>
    <v-container>
      <v-expansion-panels focusable>
        <v-expansion-panel>
          <v-expansion-panel-header>Filter</v-expansion-panel-header>
          <v-expansion-panel-content>
            <ValidationObserver ref="observer">
              <v-row>
                <v-col cols="12" sm="6" md="3">
                  <ValidationProvider rules="alpha_num" name="Username" v-slot="{ errors }">
                    <v-text-field v-model="form.username" label="Username" :error-messages="errors"></v-text-field>
                  </ValidationProvider>
                </v-col>
                <v-col cols="12" sm="6" md="3">
                  <ValidationProvider rules="min_value:1" name="Player Count" v-slot="{ errors }">
                    <v-text-field
                      v-model="form.playerCount"
                      label="Player Count"
                      type="number"
                      :error-messages="errors"
                    ></v-text-field>
                  </ValidationProvider>
                </v-col>
                <v-col cols="12" sm="6" md="3">
                  <ValidationProvider
                    rules="less_than:@maxWager|min_value:1"
                    vid="minWager"
                    name="Minimum Wager"
                    v-slot="{ errors }"
                  >
                    <v-text-field
                      v-model="form.minimumWager"
                      label="Minimum Wager"
                      type="number"
                      :error-messages="errors"
                    ></v-text-field>
                  </ValidationProvider>
                </v-col>
                <v-col cols="12" sm="6" md="3">
                  <ValidationProvider
                    rules="greater_than:@minWager|min_value:1"
                    vid="maxWager"
                    name="Maximum Wager"
                    v-slot="{ errors }"
                  >
                    <v-text-field
                      v-model="form.maximumWager"
                      label="Maximum Wager"
                      type="number"
                      :error-messages="errors"
                    ></v-text-field>
                  </ValidationProvider>
                </v-col>
              </v-row>
              <v-row>
                <v-col sm="2">
                  <v-switch v-model="form.showClosed" label="Show Closed" class="mt-1 pa-1"></v-switch>
                </v-col>
                <v-spacer />
                <v-col class="text-right">
                  <v-btn color="green" v-on:click="submit" class="ma-1">Search</v-btn>
                  <v-btn color="red" v-on:click="clear" class="ma-1">Clear</v-btn>
                </v-col>
              </v-row>
            </ValidationObserver>
          </v-expansion-panel-content>
        </v-expansion-panel>
      </v-expansion-panels>
    </v-container>
    <v-container v-if="isLoading">
      <v-skeleton-loader v-for="i in 15" :key="i" type="card" />
    </v-container>
    <v-row v-else dense>
      <v-col v-for="wager in wagers" :key="wager.id" cols="12">
        <WagerDisplay :data="wager" :game="query.game" />
      </v-col>
      <v-col class="text-center" cols="12">
        <v-pagination
          v-model="query.page"
          :length="totalPages"
          @next="searchScroll"
          @previous="searchScroll"
          @input="searchScroll"
        ></v-pagination>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import WagerDisplay from "../components/WagerDisplay";
import { ValidationObserver } from "vee-validate";

export default {
  components: {
    WagerDisplay,
    ValidationObserver
  },
  data() {
    return {
      query: {
        username: null,
        game: this.$route.params.game.toLowerCase(),
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
    searchScroll() {
      window.scrollTo({ top: 0, behavior: "smooth" });
      this.getWagers();
    },
    getWagers() {
      //api call here
      this.isLoading = true;
      this.$axios.post("/api/wagers/search", this.query).then(response => {
        console.log(response);
        if (response.status == 200) {
          this.totalPages = response.data.totalPages;
          this.wagers = response.data.list.slice();
          this.errors = [];
          this.isLoading = false;
        } else {
          this.errors = response.data.slice();
        }
      });
    },
    clear() {
      this.form.username = null;
      this.form.playerCount = null;
      this.form.showClosed = false;
      this.form.minimumWager = null;
      this.form.maximumWager = null;
      this.$refs.observer.reset();
    },
    submit() {
      this.$refs.observer.validate().then(response => {
        if (response) {
          this.setFormVars();
          this.query.page = 1;
          this.searchScroll();
        }
      });
    },
    setFormVars() {
      this.query.username = this.form.username;
      this.query.playerCount = this.form.playerCount;
      this.query.showClosed = this.form.showClosed;
      this.query.minimumWager = this.form.minimumWager;
      this.query.maximumWager = this.form.maximumWager;
    }
  },
  created() {
    this.getWagers();
  }
};
</script>
