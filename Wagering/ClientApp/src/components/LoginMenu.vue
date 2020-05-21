<template>
    <v-list dense>
        <div v-if="this.$store.getters.isAuthenticated">
            <v-list-item>
                <v-list-item-content>
                    <v-btn color="accent" block to="/profile">
                        <v-icon left>mdi-account</v-icon>
                        {{ $store.getters.displayName }}
                    </v-btn>
                </v-list-item-content>
            </v-list-item>
            <v-list-item>
                <v-list-item-content>
                    <v-btn block to="/authentication/logout">
                        <v-icon left>mdi-logout</v-icon> Logout
                    </v-btn>
                </v-list-item-content>
            </v-list-item>
        </div>
        <div v-else>
            <v-list-item>
                <v-list-item-content>
                    <v-btn color="accent" block to="/authentication/login">
                        <v-icon left>mdi-login</v-icon> Login
                    </v-btn>
                </v-list-item-content>
            </v-list-item>
            <v-list-item>
                <v-list-item-content>
                    <v-btn block to="/authentication/register">
                        <v-icon left>mdi-account-plus</v-icon> Register
                    </v-btn>
                </v-list-item-content>
            </v-list-item>
        </div>
    </v-list>
</template>
<script lang="ts">
import Vue from "vue";

export default Vue.extend({});
</script>
