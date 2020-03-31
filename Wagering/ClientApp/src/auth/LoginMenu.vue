<template>
    <v-list dense>
        <div v-if="this.$store.state.account.isAuthenticated">
            <v-list-item to="/manage" link>
                <v-list-item-action>
                    <v-icon>mdi-account</v-icon>
                </v-list-item-action>
                <v-list-item-content>
                    <v-list-item-title>Hello {{ this.$store.state.account.username }}</v-list-item-title>
                </v-list-item-content>
            </v-list-item>
            <v-list-item @click="logout" link>
                <v-list-item-action>
                    <v-icon>mdi-logout</v-icon>
                </v-list-item-action>
                <v-list-item-content>
                    <v-list-item-title>Logout</v-list-item-title>
                </v-list-item-content>
            </v-list-item>
        </div>
        <div v-else>
            <v-list-item to="/login" link>
                <v-list-item-action>
                    <v-icon>mdi-login</v-icon>
                </v-list-item-action>
                <v-list-item-content>
                    <v-list-item-title>Login</v-list-item-title>
                </v-list-item-content>
            </v-list-item>
            <v-list-item to="/register" link>
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
<script>
    import AuthService from "./AuthService";
    export default {
        name: "LoginMenu",
        methods: {
            logout() {
                AuthService.isAuthenticated().then(isAuthenticated => {
                    if (isAuthenticated) {
                        AuthService.signOut(null);
                    }
                    this.$store.dispatch("setLogout");
                });
            }
        }
    };
</script>
