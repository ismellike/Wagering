<template>
    <v-container>
        <v-row>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-skeleton-loader
                    :loading="loading"
                    type="card"
                    transition="scale-transition"
                >
                    <hosts-display :hosts="wager.hosts">
                        <template v-if="!hasAccepted" v-slot:actions>
                            <v-spacer />
                            <v-btn color="success" @click="accept"
                                >Accept</v-btn
                            >
                            <v-btn color="error" @click="decline"
                                >Decline</v-btn
                            >
                        </template>
                        <template v-else v-slot:actions>
                            <v-spacer />
                            <v-btn color="error" @click="cancel">Cancel</v-btn>
                        </template>
                    </hosts-display>
                </v-skeleton-loader>
            </v-col>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-skeleton-loader
                    :loading="loading"
                    type="card"
                    transition="scale-transition"
                >
                    <v-card>
                        <v-card-title>Wager</v-card-title>
                        <v-card-text>
                            <info-display :wager="wager" />
                        </v-card-text>
                        <v-card-actions>
                            <v-spacer />
                            <timeago
                                class="caption"
                                :datetime="wager.date"
                                autoUpdate
                            />
                        </v-card-actions>
                    </v-card>
                </v-skeleton-loader>
            </v-col>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-skeleton-loader
                    :loading="loading"
                    type="card"
                    transition="scale-transition"
                >
                    <notifications-display :notifications="notifications" />
                </v-skeleton-loader>
            </v-col>
        </v-row>
    </v-container>
</template>
<script lang="ts">
    import Vue from "vue";
    import InfoDisplay from "@/components/Wager/InfoDisplay.vue";
    import HostsDisplay from "@/components/Wager/HostsDisplay.vue";
    import NotificationsDisplay from "@/components/EventNotificationsDisplay.vue";

    export default Vue.extend({
        components: {
            "info-display": InfoDisplay,
            "hosts-display": HostsDisplay,
            "notifications-display": NotificationsDisplay,
        },
        data() {
            return {
                wager: {
                    hosts: [],
                    description: null,
                },
                loading: true,
                errors: [],
            };
        },
        methods: {
            getData() {
                this.$axios
                    .get("/api/wager/host/" + this.$route.params.id)
                    .then((result) => {
                        this.wager = result.data;
                        this.loading = false;
                    })
                    .catch((e) => {
                        this.errors = e.response.data.splice();
                    });
            },
            accept() {
                this.$axios
                    .post("/api/bid/wager/accept", this.userBid.id)
                    .then(() => {
                        this.userBid.approved = true;
                        this.$microsoft.signalr.invoke(
                            "NotifyGroup",
                            "wager_" + this.$route.params.id,
                            {
                                message:
                                    this.$store.getters.username +
                                    " has accepted the wager.",
                                isRead: false,
                                link: this.$route.path,
                            }
                        );
                    })
                    .catch((e) => {
                        this.errors = e.response.data.splice();
                    });
            },
            decline() {
                this.$axios
                    .post("/api/bid/wager/decline", this.userBid.id)
                    .then(() => {
                        this.userBid.approved = false;
                        this.$microsoft.signalr.invoke(
                            "NotifyGroup",
                            "wager_" + this.$route.params.id,
                            {
                                message:
                                    this.$store.getters.username +
                                    " has declined the wager.",
                                isRead: false,
                                link: this.$route.path,
                            }
                        );
                    })
                    .catch((e) => {
                        this.errors = e.response.data.splice();
                    });
            },
            cancel() {
                this.$axios
                    .post("/api/wager/cancel", this.$route.params.id)
                    .then(() => {
                        this.$microsoft.signalr.invoke(
                            "NotifyGroup",
                            "wager_" + this.$route.params.id,
                            {
                                message:
                                    this.$store.getters.username +
                                    " has canceled the wager.",
                                isRead: false,
                                link: this.$route.path,
                            }
                        );
                    })
                    .catch((e) => {
                        this.errors = e.response.data.splice();
                    });
            },
        },
        computed: {
            userBid() {
                return this.wager.hosts.find((host) => {
                    return host.userId == this.$store.getters.id;
                });
            },
            hasAccepted() {
                const user = this.userBid;
                if (!user) return false;
                return user.approved;
            },
            notifications() {
                if (this.wager == null || this.wager.notifications == null)
                    return null;
                return this.wager.notifications.map((x) => x.notification);
            },
        },
        created() {
            this.getData();
        },
    });
</script>
