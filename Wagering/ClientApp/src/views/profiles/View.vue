<template>
    <v-container>
        <div v-if="profile == null">
            <p v-if="error!=null" class="display-1">{{error}}</p>
            <v-skeleton-loader v-else type="card" />
        </div>
        <div v-else>
            <v-card>
                <v-card-title class="mt-2">
                    <v-badge :value="profile.isVerified" icon="mdi-check-decagram">
                        <v-avatar color="grey darken-3">
                            <v-icon>mdi-account</v-icon>
                        </v-avatar>
                    </v-badge>
                    <div class="ml-4">{{ profile.displayName }}</div>
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
                        <v-card-text class="title">{{ profile.publicKey }}</v-card-text>
                    </v-card>
                </v-card-text>
                <v-card-actions>
                    <v-data-table class="ml-auto mr-auto" :headers="headers" hide-default-footer
                                  :items="profile.ratings"></v-data-table>
                </v-card-actions>
            </v-card>
            <v-snackbar v-model="showCopy" :timeout="2000">
                The key is copied to the clipboard.
                <v-btn color="red" text @click="showCopy = false">Close</v-btn>
            </v-snackbar>
        </div>
    </v-container>
</template>
<script>
    export default {
        data() {
            return {
                name: this.$route.params.name,
                profile: null,
                error: null,
                showCopy: false,
                rating: 3,
                headers: [
                    {
                        text: 'Game',
                        align: 'left',
                        value: 'gameName',
                    },
                    { text: 'Games Played', value: 'gamesPlayed' },
                    { text: 'Rating', value: 'value' },
                ]
            };
        },
        methods: {
            getProfile() {
                this.$axios
                    .get("/api/profile/" + this.name)
                    .then(response => {
                        if (response.status == 200) {
                            this.profile = response.data;
                            this.error = null;
                        }
                    })
                    .catch(() => {
                        this.error = this.name + " is not a valid user.";
                    });
            },
            copyToClipboard() {
                this.showCopy = true;
                const el = document.createElement("textarea");
                el.value = this.profile.publicKey;
                document.body.appendChild(el);
                el.select();
                document.execCommand("copy");
                document.body.removeChild(el);
            }
        },
        created() {
            this.getProfile();
        }
    };
</script>