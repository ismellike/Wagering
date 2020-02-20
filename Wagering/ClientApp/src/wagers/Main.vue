<template>
  <v-container>
    <h1 v-mutate="onMutate" class="text-center">Wagers | Page {{ query.page }}</h1>
    <v-expansion-panels>
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
            <div class="float-right">
              <v-btn color="green" v-on:click="submit" class="mr-2">Search</v-btn>
              <v-btn color="red" v-on:click="clear">Clear</v-btn>
            </div>
          </ValidationObserver>
        </v-expansion-panel-content>
      </v-expansion-panel>
    </v-expansion-panels>
    <div v-if="isLoading">
      <v-skeleton-loader v-for="i in 15" :key="i" type="card" class="my-2" />
    </div>
    <v-row v-else dense>
      <v-col v-for="wager in wagers" :key="wager.id" cols="12">
        <WagerDisplay :data="wager" :game="query.game" class="my-2" />
      </v-col>
      <v-col class="text-center" cols="12">
        <v-pagination v-model="query.page" :length="totalPages"></v-pagination>
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
    onMutate() {
      window.scrollTo(0, 0);
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
    async clear() {
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
          if (this.query.page == 1) this.onMutate();
          else this.query.page = 1; //will get checked by mutate if changed
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
