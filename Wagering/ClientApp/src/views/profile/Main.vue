<template>
    <content-display>
        <v-card>
            <v-toolbar color="accent" dark>
                <v-toolbar-title>Manage Profile</v-toolbar-title>
            </v-toolbar>
            <v-tabs centered icons-and-text>
                <v-tab>
                    Public Key
                    <v-icon>mdi-key</v-icon>
                </v-tab>
                <v-tab :href="managePath"
                    >Account
                    <v-icon>mdi-account</v-icon>
                </v-tab>
                <v-tab-item>
                    <v-row>
                        <v-col
                            cols="12"
                            sm="8"
                            md="6"
                            lg="4"
                            xl="3"
                            class="mx-auto"
                        >
                            <template v-if="$store.getters.publicKey">
                                <v-text-field disabled />
                            </template>
                            <template v-else>
                                <v-card>
                                    <v-card-title
                                        >Add a Stellar Public Key</v-card-title
                                    >
                                    <v-card-text>
                                        <v-text-field
                                            label="Public Key"
                                            prepend-inner-icon="mdi-key"
                                            v-model="key"
                                        ></v-text-field>
                                    </v-card-text>
                                </v-card>
                            </template>
                        </v-col>
                    </v-row>
                </v-tab-item>
            </v-tabs>
        </v-card>
    </content-display>
</template>
<script lang="ts">
    import Vue from "vue";
    import { ApplicationPaths } from "@/constants/authentication";
    import { AxiosError } from "axios";

    export default Vue.extend({
        data() {
            return {
                managePath: ApplicationPaths.IdentityManagePath,
                key: null as null | string,
                error: null as null | AxiosError,
            };
        },
        methods: {
            submitKey() {
                this.$axios
                    .put("/api/profile/key/" + this.key)
                    .then((result) => {});
            },
        },
    });
</script>
