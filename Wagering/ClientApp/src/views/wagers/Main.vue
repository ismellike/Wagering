<template>
  <content-display>
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
            <validation-observer v-slot="{ handleSubmit, reset }">
              <form @submit.prevent="handleSubmit(submit)" @reset.prevent="reset">
                <v-row>
                  <v-col cols="12" sm="6" md="3">
                    <validation-provider rules="alpha_num" name="Username" v-slot="{ errors }">
                      <v-text-field
                        v-model="form.username"
                        label="Username"
                        :error-messages="errors"
                      ></v-text-field>
                    </validation-provider>
                  </v-col>
                  <v-col cols="12" sm="6" md="3">
                    <validation-provider
                      rules="min_value:1"
                      name="Player Count"
                      v-slot="{ errors }"
                    >
                      <v-text-field
                        v-model="form.playerCount"
                        label="Player Count"
                        type="number"
                        :error-messages="errors"
                      ></v-text-field>
                    </validation-provider>
                  </v-col>
                  <v-col cols="12" sm="6" md="3">
                    <validation-provider
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
                    </validation-provider>
                  </v-col>
                  <v-col cols="12" sm="6" md="3">
                    <validation-provider
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
                    </validation-provider>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col class="text-right">
                    <v-btn color="success" type="submit" class="ma-1">Search</v-btn>
                    <v-btn color="error" type="reset" class="ma-1">Clear</v-btn>
                  </v-col>
                </v-row>
              </form>
            </validation-observer>
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
                            game: wager.gameUrl,
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
      v-model="page"
      color="secondary"
      class="text-center"
      :length="totalPages"
      @next="goTo(page)"
      @previous="goTo(page)"
      @input="goTo"
    ></v-pagination>
  </content-display>
</template>
<script lang="ts">
import Vue from "vue";
import WagerDisplay from "@/components/Wager/WagerDisplay.vue";
import { RawLocation, Route } from "vue-router";

class Query {
  page?: number;
  username?: string | null;
  playerCount?: number | null;
  minimumWager?: number | null;
  maximumWager?: number | null;
  game?: string;
  constructor(game: string) {
    this.page = 1;
    this.username = null;
    this.game = game;
    this.playerCount = null;
    this.minimumWager = null;
    this.maximumWager = null;
  }
  setVars(route: Record<string, string | (string | null)[]>): void {
    this.page = route.Page ? Number(route.page) : 1;
    this.username = route.username ? String(route.username) : undefined;
    this.playerCount = route.playerCount
      ? Number(route.playerCount)
      : undefined;
    this.minimumWager = route.minimumWager
      ? Number(route.minimumWager)
      : undefined;
    this.maximumWager = route.maximumWager
      ? Number(route.maximumWager)
      : undefined;
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
  routeQuery(): Record<string, string | (string | null)[]> {
    return {
      page: this.page && this.page > 1 ? String(this.page) : undefined,
      username: this.username ? this.username : undefined,
      playerCount:
        this.playerCount && this.playerCount > 0
          ? String(this.playerCount)
          : undefined,
      minimumWager:
        this.minimumWager && this.minimumWager > 0
          ? String(this.minimumWager)
          : undefined,
      maximumWager:
        this.maximumWager && this.maximumWager > 0
          ? String(this.maximumWager)
          : undefined
    } as Record<string, string | (string | null)[]>;
  }
}

export default Vue.extend({
  components: {
    "wager-display": WagerDisplay
  },
  data() {
    return {
      query: new Query(this.$route.params.game),
      form: {
        username: null,
        playerCount: null,
        minimumWager: null,
        maximumWager: null
      } as Query,
      wagers: [] as Wager[],
      page: 1 as number,
      totalPages: 0 as number,
      showFilter: false as boolean,
      loading: true as boolean
    };
  },
  methods: {
    goTo(i: number): void {
      if (i == this.query.page) return;
      this.query.page = i;
      this.$router.push({
        name: "wagers",
        params: { game: this.query.game },
        query: this.query.routeQuery()
      } as RawLocation);
    },
    getWagers(): void {
      //api call here
      this.loading = true;
      this.$axios.post("/api/wager/search", this.query).then(response => {
        this.totalPages = response.data.totalPages;
        this.wagers = response.data.list.slice();
        this.loading = false;
      });
    },
    submit(): void {
      this.query.copyForm(this.form);
      this.$router.push({
        name: "wagers",
        params: { game: this.query.game },
        query: this.query.routeQuery()
      } as RawLocation);
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
});
</script>
