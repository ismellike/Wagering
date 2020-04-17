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

        <v-app-bar app color="accent" dense clipped-right>
            <v-toolbar-title>Wagering.gg</v-toolbar-title>
            <v-spacer />
            <v-tooltip left>
                <template v-slot:activator="{ on }">
                    <v-badge :content="notifications.length"
                             :value="notifications.length"
                             color="info"
                             offset-y="22"
                             offset-x="20">
                        <v-btn color="warning" icon v-on="on" @click.stop="dialog = true">
                            <v-icon>
                                mdi-bell
                            </v-icon>
                        </v-btn>
                    </v-badge>
                </template>
                <span>Notifications</span>
            </v-tooltip>
            <v-dialog v-model="dialog"
                      max-width="500">
                <v-card>
                    <v-card-title>Notifications</v-card-title>

                    <v-card-text>
                        <v-list two-line>
                            <v-list-item v-for="(notification, i) in notifications" :key="i">
                                <v-list-item-content>
                                    <v-list-item-title>
                                        {{ notification.message }}
                                    </v-list-item-title>
                                    <v-list-item-subtitle>{{ $timeAgo.format(notification.date) }} </v-list-item-subtitle>
                                </v-list-item-content>
                                <v-list-item-action>
                                    <template>
                                        <v-btn icon @click="deleteNotification(i)">
                                            <v-icon color="error">mdi-delete</v-icon>
                                        </v-btn>
                                        <v-btn icon :to="notification.link">
                                            <v-icon>
                                                mdi-subdirectory-arrow-right
                                            </v-icon>
                                        </v-btn>
                                    </template>
                                </v-list-item-action>
                            </v-list-item>
                        </v-list>
                    </v-card-text>

                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn text
                               color="error"
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
    import AuthService from "@/services/authentication";
    import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

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
                errors: [],
                dialog: false
            };
        },
        methods: {
            receiveNotifications() {
                this.$microsoft.signalr.on("GetNotification", (notification) => {
                    this.notifications.push(notification);
                });
            },
            deleteNotification(index) {
                this.notifications.splice(index, 1);
            },
            receiveGroups() {
                this.$microsoft.signalr.on("ReceiveGroup", (name, notification) => {
                    this.notifications.push(notification);
                    this.$microsoft.signalr.invoke("AddToGroup", name);
                });
            },
            addGroups() {
                this.$axios.get("/api/group").then(result => {
                    result.data.forEach(group => {
                        this.$microsoft.signalr.invoke("AddToGroup", group);
                    });
                });
            },
            getNotifications() {
                this.$axios.get("/api/notification").then(result => {
                    result.data.forEach(notification => {
                        this.notifications.push(notification);
                    });
                });
            },
            listen() {
                this.receiveNotifications();
                this.receiveGroups();
            }
        },
        created() {
            if (this.$store.state.account.isAuthenticated) {
                AuthService.getAccessToken().then(accessToken => {
                    if (accessToken) {
                        if (accessToken != this.$store.state.account.token) {
                            var payload = {
                                username: this.$store.state.account.username,
                                token: accessToken
                            }
                            this.$store.dispatch("setLogin", payload);
                        }
                    }
                    else {
                        this.$store.dispatch("setLogout");
                    }
                });
            }

            this.$axios.interceptors.request.use(request => {
                if (process.env.NODE_ENV == "development") {
                    console.log("REQUEST", request);
                }
                if (this.$store.state.account.isAuthenticated) {
                    request.headers.Authorization = `Bearer ${this.$store.state.account.token}`;
                }
                return request;
            }, function (err) {
                if (process.env.NODE_ENV == "development") {
                    console.log("ERROR", err);
                }
                return Promise.reject(err);
            });

            this.$axios.interceptors.response.use(response => {
                if (process.env.NODE_ENV == "development") {
                    console.log("RESPONSE", response);
                }
                return response;
            }, function (err) {
                if (process.env.NODE_ENV == "development") {
                    console.log("ERROR", err);
                }
                if (err.response.status == 401) {
                    if (!window.location.href.includes("authentication"))
                        window.location = "/authentication/login";
                }
                return Promise.reject(err);
            });
        },
        mounted() {
            if (this.$store.state.account.isAuthenticated && !this.$route.path.includes("authentication")) {
                this.$microsoft.signalr = new HubConnectionBuilder()
                    .withUrl("/group-hub", { accessTokenFactory: () => this.$store.state.account.token })
                    .configureLogging(LogLevel.Information)
                    .withAutomaticReconnect()
                    .build();
                this.$microsoft.signalr.start().then(() => {
                    this.listen();
                    this.addGroups();
                });
                this.getNotifications();
            }
        }
    };
</script>
