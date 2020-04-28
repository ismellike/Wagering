<template>
    <v-container>
        <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
            <v-row dense>
                <v-col cols="12">
                    <wager-display :wager="wager" />
                </v-col>
            </v-row>
            <v-container>
                <v-expansion-panels v-if="!isHost" focusable>
                    <v-expansion-panel>
                        <v-expansion-panel-header class="title">Apply</v-expansion-panel-header>
                        <v-expansion-panel-content v-if="this.$store.state.account.isAuthenticated">
                            <v-container></v-container>
                            <!--Apply logic here-->
                        </v-expansion-panel-content>
                        <v-expansion-panel-content v-else>
                            <v-container>Sign in to apply for a wager.</v-container>
                        </v-expansion-panel-content>
                    </v-expansion-panel>
                </v-expansion-panels>
            </v-container>
            <v-row dense>
                <v-col cols="12" sm="6" v-for="challenge in wager.challenges" :key="challenge.id">
                    <challenge-display :data="challenge" />
                </v-col>
            </v-row>
        </v-skeleton-loader>
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
                wager: null,
                id: this.$route.params.id,
                game: this.$route.params.game,
                isHost: false,
                loading: true,
                errors: []
            };
        },
        methods: {
            getWager() {
                this.$axios.get("/api/wager/" + this.id).then(response => {
                    this.wager = response.data;
                    this.loading = false;
                    //check if user is part of hosts
                }).catch(e => {
                    this.errors = e.response.data.splice();
                });
            }
        },
        created() {
            this.getWager();
        }
    };
</script>
