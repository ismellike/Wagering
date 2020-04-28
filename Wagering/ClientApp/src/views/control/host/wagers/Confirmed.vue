<template>
    <v-container>
        <v-row>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
                    <hosts-display :hosts="wager.hosts"></hosts-display>
                </v-skeleton-loader>
            </v-col>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
                    <v-card>
                        <v-card-title>Wager</v-card-title>
                        <v-card-text>
                            <info-display :wager="wager" />
                        </v-card-text>
                        <v-card-actions>
                            <v-spacer />
                            <timeago class="caption" :datetime="wager.date" autoUpdate />
                        </v-card-actions>
                    </v-card>
                </v-skeleton-loader>
            </v-col>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
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
            </v-col>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
                    <notifications-display :notifications="notifications" />
                </v-skeleton-loader>
            </v-col>
        </v-row>
    </v-container>
</template>
<script>
    import InfoDisplay from "@/components/Wager/InfoDisplay";
    import HostsDisplay from "@/components/Wager/HostsDisplay";
    import ChallengeDisplay from "@/components/Wager/ChallengeDisplay";
    import NotificationsDisplay from "@/components/EventNotificationsDisplay";
    export default {
        components: {
            "info-display": InfoDisplay,
            "hosts-display": HostsDisplay,
            "challenge-display": ChallengeDisplay,
            "notifications-display": NotificationsDisplay
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
        computed: {
            notifications() {
                if (this.wager == null || this.wager.notifications == null)
                    return null;
                return this.wager.notifications.map(x => x.notification);
            }
        },
        created() {
            this.getData();
        }
    };
</script>