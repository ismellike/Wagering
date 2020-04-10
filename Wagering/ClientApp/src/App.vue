<template>
    <v-app id="app">
        <v-navigation-drawer v-model="drawer"
                             color="grey darken-4"
                             clipped
                             app
                             right
                             dark
                             height="100%">
            <v-list dense>
                <v-list-item to="/" link>
                    <v-list-item-action>
                        <v-icon>mdi-home</v-icon>
                    </v-list-item-action>

                    <v-list-item-content>
                        <v-list-item-title>Home</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>

                <v-list-item to="/about" link>
                    <v-list-item-action>
                        <v-icon>mdi-information-outline</v-icon>
                    </v-list-item-action>

                    <v-list-item-content>
                        <v-list-item-title>About</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
                <v-list-item to="/hub" link>
                    <v-list-item-action>
                        <v-icon>mdi-gamepad-variant</v-icon>
                    </v-list-item-action>

                    <v-list-item-content>
                        <v-list-item-title>The Hub</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
                <v-list-item v-if="this.$store.state.account.isAuthenticated" to="/host-panel" link>
                    <v-list-item-action>
                        <v-icon>mdi-clipboard</v-icon>
                    </v-list-item-action>

                    <v-list-item-content>
                        <v-list-item-title>Host Panel</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
                <v-list-item v-if="this.$store.state.account.isAuthenticated" to="/client-panel" link>
                    <v-list-item-action>
                        <v-icon>mdi-clipboard-multiple</v-icon>
                    </v-list-item-action>

                    <v-list-item-content>
                        <v-list-item-title>Client Panel</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
            </v-list>
            <template v-slot:append>
                <LoginMenu />
            </template>
        </v-navigation-drawer>

        <v-app-bar app color="deep-purple" dense clipped-right dark>
            <v-toolbar-title>Wagering.gg</v-toolbar-title>
            <v-spacer />
            <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
        </v-app-bar>

        <v-content>
            <v-container class="fill-height" fluid>
                <router-view />
            </v-container>
        </v-content>

        <v-footer absolute inset clipped-right app dark>
            <v-btn href="https://discord.gg/HmmVMs2" target="_blank" icon>
                <v-icon dense>mdi-discord</v-icon>
            </v-btn>
            <v-btn href="https://www.instagram.com/wagering.gg" target="_blank" icon>
                <v-icon dense>mdi-instagram</v-icon>
            </v-btn>
            <v-btn href="https://twitter.com/WageringGG" target="_blank" icon>
                <v-icon dense>mdi-twitter</v-icon>
            </v-btn>
            <v-spacer />2020 - Wagering.gg
        </v-footer>
    </v-app>
</template>

<script>
    import LoginMenu from "@/components/LoginMenu.vue";

    export default {
        name: "App",
        props: {
            source: String
        },
        components: {
            LoginMenu
        },
        data: () => ({
            drawer: null
        }),
        methods: {
        },
        created() {
            this.$vuetify.theme.dark = true;

            this.$axios.interceptors.request.use(request => {
                if (process.env.NODE_ENV == "development") {
                    console.log("REQUEST", request);
                }
                if (this.$store.state.account.isAuthenticated) {
                    request.headers.Authorization = `Bearer ${this.$store.state.account.token}`;
                }
                return request;
            }, function (err) {
                return Promise.reject(err);
            });

            this.$axios.interceptors.response.use(response => {
                if (process.env.NODE_ENV == "development") {
                    console.log("RESPONSE", response);
                }
                return response;
            }, function (err) {
                if (err.response.status == 401) {
                    window.location = "/authentication/login";
                }
                return Promise.reject(err);
            });

            //poll every x seconds for new notifications
        }
    };
</script>
