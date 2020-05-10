<template>
    <content-display>
        <v-container>
            <v-skeleton-loader
                :loading="loading"
                type="card"
                transition="scale-transition"
            >
                <hosts-display :hosts="wager.hosts"></hosts-display>
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
        <v-container>
            <v-skeleton-loader
                :loading="loading"
                type="card"
                transition="scale-transition"
            >
                <v-card>
                    <v-card-title>Challenges</v-card-title>
                    <v-card-text>
                        <template
                            v-if="
                                wager.challenges && wager.challenges.length > 0
                            "
                        >
                            <v-container
                                v-for="challenge in wager.challenges"
                                v-bind:key="challenge.id"
                            >
                                <challenge-display :challenge="challenge" />
                            </v-container>
                        </template>
                        <template v-else
                            >There's currently no challenges.</template
                        >
                    </v-card-text>
                </v-card>
            </v-skeleton-loader>
        </v-container>
    </content-display>
</template>
<script lang="ts">
import Vue from "vue";
import InfoDisplay from "@/components/Wager/InfoDisplay.vue";
import HostsDisplay from "@/components/Wager/HostsDisplay.vue";
import ChallengeDisplay from "@/components/Wager/ChallengeDisplay.vue";

export default Vue.extend({
    components: {
        "info-display": InfoDisplay,
        "hosts-display": HostsDisplay,
        "challenge-display": ChallengeDisplay
    },
    data() {
        return {
            wager: {} as Wager,
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
        }
    },
    created(): void {
        this.getData();
    }
});
</script>
