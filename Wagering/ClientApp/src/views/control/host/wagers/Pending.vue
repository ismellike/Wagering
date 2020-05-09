<template>
    <content-display>
        <v-container>
            <v-skeleton-loader
                :loading="loading"
                type="card"
                transition="scale-transition"
            >
                <hosts-display :hosts="wager.hosts">
                    <template v-if="!hasAccepted" v-slot:actions>
                        <v-spacer />
                        <v-btn color="success" @click="accept">Accept</v-btn>
                        <v-btn color="error" @click="decline">Decline</v-btn>
                    </template>
                    <template v-else v-slot:actions>
                        <v-spacer />
                        <v-btn color="error" @click="cancel">Cancel</v-btn>
                    </template>
                </hosts-display>
            </v-skeleton-loader>
        </v-container>
        <v-container>
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
        </v-container>
    </content-display>
</template>
<script lang="ts">
import Vue from "vue";
import InfoDisplay from "@/components/Wager/InfoDisplay.vue";
import HostsDisplay from "@/components/Wager/HostsDisplay.vue";

export default Vue.extend({
    components: {
        "info-display": InfoDisplay,
        "hosts-display": HostsDisplay
    },
    data() {
        return {
            wager: {
                hosts: [],
                notifications: [],
                minimumWager: null,
                maximumWager: null,
                description: ""
            } as Wager,
            loading: true as boolean
        };
    },
    methods: {
        getData(): void {
            this.$axios
                .get("/api/wager/host/" + this.$route.params.id)
                .then(response => {
                    this.wager = response.data;
                    this.loading = false;
                });
        },
        accept(): void {
            if (this.userBid)
                this.$axios
                    .post("/api/bid/wager/accept", this.userBid.id)
                    .then(() => {
                        if (this.userBid) this.userBid.approved = true;
                        this.$microsoft.signalr.invoke(
                            "NotifyGroup",
                            "wager_" + this.$route.params.id,
                            {
                                message:
                                    this.$store.getters.username +
                                    " has accepted the wager.",
                                isRead: false,
                                link: this.$route.path
                            }
                        );
                    });
        },
        decline(): void {
            if (this.userBid)
                this.$axios
                    .post("/api/bid/wager/decline", this.userBid.id)
                    .then(() => {
                        if (this.userBid) this.userBid.approved = false;
                        this.$microsoft.signalr.invoke(
                            "NotifyGroup",
                            "wager_" + this.$route.params.id,
                            {
                                message:
                                    this.$store.getters.username +
                                    " has declined the wager.",
                                isRead: false,
                                link: this.$route.path
                            }
                        );
                    });
        },
        cancel(): void {
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
                            link: this.$route.path
                        }
                    );
                });
        }
    },
    computed: {
        userBid(): WagerHostBid | null {
            return (
                this.wager?.hosts?.find((host: WagerHostBid) => {
                    return host.userId == this.$store.getters.id;
                }) ?? null
            );
        },
        hasAccepted(): boolean {
            const user = this.userBid;
            return user?.approved ?? false;
        }
    },
    created(): void {
        this.getData();
    }
});
</script>
