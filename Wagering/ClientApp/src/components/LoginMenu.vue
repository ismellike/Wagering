<template>
    <v-list dense>
        <div v-if="this.$store.getters.isAuthenticated">
            <v-list-item to="/authentication/profile" link>
                <v-list-item-action>
                    <v-icon>mdi-account</v-icon>
                </v-list-item-action>
                <v-list-item-content>
                    <v-list-item-title>
                        {{ $store.getters.displayName }}
                    </v-list-item-title>
                </v-list-item-content>
            </v-list-item>
            <v-list-item to="/authentication/logout" link>
                <v-list-item-action>
                    <v-icon>mdi-logout</v-icon>
                </v-list-item-action>
                <v-list-item-content>
                    <v-list-item-title>Logout</v-list-item-title>
                </v-list-item-content>
            </v-list-item>
        </div>
        <div v-else>
            <v-list-item to="/authentication/login" link>
                <v-list-item-action>
                    <v-icon>mdi-login</v-icon>
                </v-list-item-action>
                <v-list-item-content>
                    <v-list-item-title>Login</v-list-item-title>
                </v-list-item-content>
            </v-list-item>
            <v-list-item to="/authentication/register" link>
                <v-list-item-action>
                    <v-icon>mdi-account-plus</v-icon>
                </v-list-item-action>
                <v-list-item-content>
                    <v-list-item-title>Register</v-list-item-title>
                </v-list-item-content>
            </v-list-item>
        </div>
    </v-list>
</template>
<script lang="ts">
import Vue from "vue";

export default Vue.extend({});
</script>
