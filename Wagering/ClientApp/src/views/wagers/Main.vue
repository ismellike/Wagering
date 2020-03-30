<template>
    <v-container>
        <v-container>
            <h1 class="text-center">Wagers | Page {{ query.page }}</h1>
        </v-container>
        <v-container class="text-right">
            <v-btn :to="{ name:'wager_create', params:{game:query.game}}">
                <v-icon left>mdi-plus-circle</v-icon>Create
            </v-btn>
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
                                        <v-text-field v-model="form.playerCount"
                                                      label="Player Count"
                                                      type="number"
                                                      :error-messages="errors"></v-text-field>
                                    </ValidationProvider>
                                </v-col>
                                <v-col cols="12" sm="6" md="3">
                                    <ValidationProvider rules="less_than:@maxWager|min_amount"
                                                        vid="minWager"
                                                        name="Minimum Wager"
                                                        v-slot="{ errors }">
                                        <v-text-field v-model="form.minimumWager"
                                                      label="Minimum Wager"
                                                      type="number"
                                                      :error-messages="errors"></v-text-field>
                                    </ValidationProvider>
                                </v-col>
                                <v-col cols="12" sm="6" md="3">
                                    <ValidationProvider rules="greater_than:@minWager|min_amount"
                                                        vid="maxWager"
                                                        name="Maximum Wager"
                                                        v-slot="{ errors }">
                                        <v-text-field v-model="form.maximumWager"
                                                      label="Maximum Wager"
                                                      type="number"
                                                      :error-messages="errors"></v-text-field>
                                    </ValidationProvider>
                                </v-col>
                            </v-row>
                            <v-row>
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
        <div v-if="isLoading">
            <v-row dense v-for="i in 15" :key="i">
                <v-col>
                    <v-container>
                        <v-skeleton-loader type="card" />
                    </v-container>
                </v-col>
            </v-row>
        </div>
        <div v-else>
            <v-row dense v-for="wager in wagers" :key="wager.id">
                <v-col>
                    <v-container>
                        <WagerDisplay :data="wager" :code="1" />
                    </v-container>
                </v-col>
            </v-row>
            <v-pagination v-model="query.page"
                          class="text-center"
                          :length="totalPages"
                          @next="goTo"
                          @previous="goTo"
                          @input="goTo"></v-pagination>
        </div>
    </v-container>
</template>
<script>
    import WagerDisplay from "@/components/WagerDisplay";
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
                    minimumWager: null,
                    maximumWager: null
                },
                form: {
                    username: null,
                    playerCount: null,
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
            goTo() {
                this.$router.push({
                    name: "wagers", params: { game: this.query.game }, query: this.getQuery()
                });
            },
            getWagers() {
                //api call here
                this.isLoading = true;
                this.$axios.post("/api/wagers/search", this.query).then(response => {
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
                this.form.minimumWager = null;
                this.form.maximumWager = null;
                this.$refs.observer.reset();
            },
            submit() {
                this.$refs.observer.validate().then(response => {
                    if (response) {
                        this.setFormVars();
                        this.$router.push({
                            name: "wagers", params: { game: this.query.game }, query: this.getQuery()
                        });
                    }
                });
            },
            getQuery() {
                return {
                    ...(this.query.page !== 1) && { page: this.query.page },
                    ...(this.query.username) && { username: this.query.username },
                    ...(this.query.playerCount) && { playerCount: this.query.playerCount },
                    ...(this.query.minimumWager) && { minimumWager: this.query.minimumWager },
                    ...(this.query.maximumWager) && { maximumWager: this.query.maximumWager },
                };
            },
            setFormVars() {
                this.query.page = 1;
                this.query.username = this.form.username;
                this.query.playerCount = this.form.playerCount;
                this.query.minimumWager = this.form.minimumWager;
                this.query.maximumWager = this.form.maximumWager;
            },
            setQueryVars(query) {
                Object.keys(query).forEach(key => {
                    this.query[key] = query[key];
                });
                this.query.page = Number(this.query.page);
            }
        },
        beforeRouteUpdate(to, from, next) {
            if (to.path == from.path) {
                this.setQueryVars(to.query)
                this.getWagers();
            }
            next();
        },
        created() {
            this.setQueryVars(this.$route.query);
            this.getWagers();
        }
    };
</script>
