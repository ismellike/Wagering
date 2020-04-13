<template>
    <v-app id="app">
        <v-navigation-drawer v-model="drawer"
                             clipped
                             app
                             right
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

        <v-app-bar app color="primary" dense clipped-right>
            <v-toolbar-title>Wagering.gg</v-toolbar-title>
            <v-spacer />
            <v-tooltip left>
                <template v-slot:activator="{ on }">
                    <v-badge :content="notifications.length"
                             :value="notifications.length"
                             color="green"
                             overlap>
                        <v-btn icon v-on="on" @click.stop="dialog = true">
                            <v-icon>
                                mdi-bell
                            </v-icon>
                        </v-btn>
                    </v-badge>
                </template>
                <span>Notifications</span>
            </v-tooltip>
            <v-dialog v-model="dialog"
                      max-width="290">
                <v-card>
                    <v-card-title>Notifications</v-card-title>

                    <v-card-text>
                        Show notifications here
                    </v-card-text>

                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn text
                               @click="dialog = false">
                            Close
                        </v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
            <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
        </v-app-bar>

        <v-content>
            <v-container class="fill-height" fluid>
                <router-view />
            </v-container>
        </v-content>

        <v-footer inset clipped-right app>
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
        data() {
            return {
                drawer: null,
                notifications: [],
                dialog: false
            };
        },
        methods: {
            connectHub() {
                this.$signalr.start();
            },
            receiveNotifications() {
                this.$signalr.on("GetNotifications", (message) => {
                    this.notifications.push(message);
                });
            }
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

            if (this.$store.state.account.isAuthenticated) {
                this.connectHub();
                this.receiveNotifications();
            }
        }
    };
</script>
