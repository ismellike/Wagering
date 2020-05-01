<template>
    <v-container>
        <v-container>
            <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
                <wager-display :wager="wager">
                    <template v-if="!isHost && $store.getters.isAuthenticated" v-slot:button>
                        <v-btn color="secondary" :to="{ name: 'wager_apply', params: { id: wager.id, game: $route.params.game }}">
                            Apply
                        </v-btn>
                    </template>
                </wager-display>
            </v-skeleton-loader>
        </v-container>
        <v-container v-if="!isHost">
            <v-expansion-panels v-if="!isHost">
                <v-expansion-panel>
                    <v-expansion-panel-header class="title">Apply</v-expansion-panel-header>
                    <v-expansion-panel-content>
                        <v-container v-if="$store.getters.isAuthenticated">
                            <!--Logic-->
                        </v-container>
                        <v-container v-else>Sign in to apply.</v-container>
                    </v-expansion-panel-content>
                </v-expansion-panel>
            </v-expansion-panels>
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
                        <template v-else>
                            There's currently no challenges.
                        </template>
                    </v-card-text>
                </v-card>
            </v-skeleton-loader>
        </v-container>
    </v-container>
</template>
<script>
    import WagerDisplay from "@/components/Wager/WagerDisplay";
    import ChallengeDisplay from "@/components/Wager/ChallengeDisplay";
    export default {
        components: {
            "wager-display": WagerDisplay,
            "challenge-display": ChallengeDisplay
        },
        data() {
            return {
                wager: {},
                id: this.$route.params.id,
                game: this.$route.params.game,
                loading: true,
                errors: []
            };
        },
        methods: {
            getWager() {
                this.$axios.get("/api/wager/" + this.id).then(response => {
                    this.wager = response.data;
                    this.loading = false;
                }).catch(e => {
                    this.errors = e.response.data.splice();
                });
            }
        },
        created() {
            this.getWager();
        },
        computed: {
            isHost() {
                if (!this.$store.getters.isAuthenticated)
                    return false;
                if (this.wager == null || this.wager.hosts == null)
                    return false;
                return this.wager.hosts.some(x => x.userId == this.$store.getters.id);
            }
        }
    };
</script>
