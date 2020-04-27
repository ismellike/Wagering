<template>
    <v-container>
        <v-row>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
                    <WagerHostsDisplay :hosts="wager.hosts"></WagerHostsDisplay>
                </v-skeleton-loader>
            </v-col>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
                    <v-card>
                        <v-card-title>Wager</v-card-title>
                        <v-card-text>
                            <WagerInfoDisplay :wager="wager" />
                        </v-card-text>
                        <v-card-actions>
                            <v-spacer />
                            <timeago class="caption" since="wager.date" :auto-update="60"/>
                        </v-card-actions>
                    </v-card>
                </v-skeleton-loader>
            </v-col>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
                    <v-card>
                        <v-card-title>Challenges</v-card-title>
                        <v-card-text>
                            <WagerChallengeDisplay  />
                        </v-card-text>
                    </v-card>
                </v-skeleton-loader>
            </v-col>
        </v-row>
    </v-container>
</template>
<script>
    import WagerInfoDisplay from "@/components/WagerInfoDisplay";
    import WagerHostsDisplay from "@/components/WagerHostsDisplay";
    import WagerChallengeDisplay from "@/components/WagerChallengeDisplay";
    export default {
        components: {
            WagerInfoDisplay,
            WagerHostsDisplay,
            WagerChallengeDisplay
        },
        data() {
            return {
                wager: {
                    hosts: [],
                    description: null
                },
                loading: true,
                errors: []
            };
        },
        methods: {
            getData() {
                this.$axios
                    .get("/api/wager/host/" + this.$route.params.id)
                    .then(result => {
                        this.wager = result.data;
                        this.loading = false;
                    })
                    .catch(e => {
                        this.errors = e.response.data.splice();
                    });
            }
        },
        computed: {},
        created() {
            this.getData();
        }
    };
</script>