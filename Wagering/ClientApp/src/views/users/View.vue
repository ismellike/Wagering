<template>
    <content-display>
        <v-skeleton-loader
            type="card"
            transition="scale-transition"
            :loading="loading"
        >
            <v-card>
                <v-card-title class="mt-2">
                    <v-badge :value="user.isVerified" icon="mdi-check-decagram">
                        <v-avatar color="grey darken-3">
                            <v-icon>mdi-account</v-icon>
                        </v-avatar>
                    </v-badge>
                    <div class="ml-4">{{ user.displayName }}</div>
                </v-card-title>
                <v-card-text>
                    <v-card color="grey darken-3">
                        <v-card-title>
                            Public Key
                            <v-spacer />
                            <v-btn fab small @click="copyToClipboard">
                                <v-icon>mdi-content-copy</v-icon>
                            </v-btn>
                        </v-card-title>
                        <v-card-text class="title">
                            {{ user.publicKey }}
                        </v-card-text>
                    </v-card>
                </v-card-text>
                <v-card-actions>
                    <v-data-table
                        class="ml-auto mr-auto"
                        :headers="headers"
                        hide-default-footer
                        :items="user.ratings"
                    ></v-data-table>
                </v-card-actions>
            </v-card>
        </v-skeleton-loader>
        <v-snackbar v-model="showCopy" :timeout="2000">
            The key is copied to the clipboard.
            <v-btn color="error" text @click="showCopy = false">Close</v-btn>
        </v-snackbar>
    </content-display>
</template>
<script lang="ts">
import Vue from "vue";

export default Vue.extend({
    data() {
        return {
            name: this.$route.params.name as string,
            user: {} as Profile,
            loading: true as boolean,
            showCopy: false as boolean,
            rating: 0 as number,
            headers: [
                {
                    text: "Game",
                    align: "left",
                    value: "gameName"
                },
                { text: "Games Played", value: "gamesPlayed" },
                { text: "Rating", value: "value" }
            ]
        };
    },
    methods: {
        getUser(): void {
            this.$axios.get("/api/user/" + this.name).then(response => {
                this.loading = false;
                this.user = response.data;
            });
        },
        copyToClipboard(): void {
            this.showCopy = true;
            const el = document.createElement("textarea");
            el.value = this.user.publicKey ?? "";
            document.body.appendChild(el);
            el.select();
            document.execCommand("copy");
            document.body.removeChild(el);
        }
    },
    created(): void {
        this.getUser();
    }
});
</script>
