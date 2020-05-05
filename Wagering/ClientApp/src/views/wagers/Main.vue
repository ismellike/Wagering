<template>
  <v-container>
    <v-container>
      <h1 class="text-center">Wagers</h1>
    </v-container>
    <v-container v-if="$store.getters.isAuthenticated" class="text-right">
      <v-btn color="secondary" :to="{ name: 'wager_create', params: { game: query.game } }">
        <v-icon left>mdi-plus-circle</v-icon>Create
      </v-btn>
    </v-container>
    <v-container>
      <v-expansion-panels>
        <v-expansion-panel>
          <v-expansion-panel-header color="accent">Filter</v-expansion-panel-header>
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
                    rules="less_than:@maxWager|min_amount"
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
                    rules="greater_than:@minWager|min_amount"
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
                <v-col class="text-right">
                  <v-btn color="success" v-on:click="submit" class="ma-1">Search</v-btn>
                  <v-btn color="error" v-on:click="clear" class="ma-1">Clear</v-btn>
                </v-col>
              </v-row>
            </ValidationObserver>
          </v-expansion-panel-content>
        </v-expansion-panel>
      </v-expansion-panels>
    </v-container>
    <v-container>
      <v-row v-for="wager in wagers" :key="wager.id">
        <v-col>
          <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
            <wager-display :wager="wager">
              <template v-slot:button>
                <v-btn
                  color="secondary"
                  :to="{
                                        name: 'wager_view',
                                        params: {
                                            game: wager.gameName,
                                            id: wager.id,
                                        },
                                    }"
                  class="mr-2"
                >View</v-btn>
              </template>
            </wager-display>
          </v-skeleton-loader>
        </v-col>
      </v-row>
    </v-container>
    <v-pagination
      v-model="query.page"
      color="secondary"
      class="text-center"
      :length="totalPages"
      @next="goTo"
      @previous="goTo"
      @input="goTo"
    ></v-pagination>
  </v-container>
</template>
<script lang="ts">
import WagerDisplay from "@/components/Wager/WagerDisplay.vue";
import { AxiosResponse } from "axios";
import { Route } from "vue-router";
class Query {
  page?: number;
  username?: string | null;
  playerCount?: number | null;
  minimumWager?: number | null;
  maximumWager?: number | null;
  game?: string;

  setVars(query: Query): void {
    this.page = query.page;
    this.username = query.username;
    this.playerCount = query.playerCount;
    this.minimumWager = query.minimumWager;
    this.maximumWager = query.maximumWager;
  }

  copyForm(query: Query): void {
    this.page = 1;
    this.username = query.username;
    this.playerCount = query.playerCount;
    this.minimumWager = query.minimumWager;
    this.maximumWager = query.maximumWager;
  }

  clear(): void {
    this.username = null;
    this.playerCount = null;
    this.minimumWager = null;
    this.maximumWager = null;
  }

  routeQuery(): Query {
    return {
      page: this.page > 1 ? this.page : undefined,
      username: this.username ? this.username : undefined,
      playerCount:
        this.playerCount && this.playerCount > 0 ? this.playerCount : undefined,
      minimumWager:
        this.minimumWager && this.minimumWager > 0
          ? this.minimumWager
          : undefined,
      maximumWager:
        this.maximumWager && this.maximumWager > this.minimumWager
          ? this.maximumWager
          : undefined
    } as Query;
  }
}
export default {
  components: {
    "wager-display": WagerDisplay
  },
  data() {
    return {
      query: {
        username: null,
        game: this.$route.params.game,
        page: 1,
        playerCount: null,
        minimumWager: null,
        maximumWager: null
      } as Query,
      form: {
        username: null,
        playerCount: null,
        minimumWager: null,
        maximumWager: null
      } as Query,
      wagers: [] as Wager[],
      totalPages: 0 as number,
      showFilter: false as boolean,
      loading: true as boolean
    };
  },
  methods: {
    goTo(): void {
      this.$router.push({
        name: "wagers",
        params: { game: this.query.game },
        query: this.query.routeQuery()
      });
    },
    getWagers(): void {
      //api call here
      this.loading = true;
      this.$axios
        .post("/api/wager/search", this.query)
        .then((response: AxiosResponse) => {
          this.totalPages = response.data.totalPages;
          this.wagers = response.data.list.slice();
          this.loading = false;
        });
    },
    clear() {
      this.form.clear();
      this.$refs.observer.reset();
    },
    submit() {
      this.$refs.observer.validate().then((response: AxiosResponse) => {
        if (response) {
          this.query.copyForm(this.form);
          this.$router.push({
            name: "wagers",
            params: { game: this.query.game },
            query: this.query.routeQuery()
          });
        }
      });
    }
  },
  beforeRouteUpdate(to: Route, from: Route, next: Function): void {
    if (to.path == from.path) {
      this.query.setVars(to.query);
      this.getWagers();
    }
    next();
  },
  created(): void {
    this.query.setVars(this.$route.query);
    this.getWagers();
  }
};
</script>
