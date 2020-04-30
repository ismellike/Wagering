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
                <template v-if="$store.getters.isAuthenticated">
                    <v-list-item to="/host" link>
                        <v-list-item-action>
                            <v-badge :content="notifications.length"
                                     :value="notifications.length"
                                     color="error"
                                     overlap>
                                <v-icon>
                                    mdi-clipboard
                                </v-icon>
                            </v-badge>
                        </v-list-item-action>

                        <v-list-item-content>
                            <v-list-item-title>
                                Host Panel
                            </v-list-item-title>
                        </v-list-item-content>
                    </v-list-item>
                    <v-list-item to="/client" link>
                        <v-list-item-action>
                            <v-icon>mdi-clipboard-multiple</v-icon>
                        </v-list-item-action>

                        <v-list-item-content>
                            <v-list-item-title>Client Panel</v-list-item-title>
                        </v-list-item-content>
                    </v-list-item>
                </template>
            </v-list>
            <template v-slot:append>
                <login-menu />
            </template>
        </v-navigation-drawer>

        <v-app-bar app color="accent" dense clipped-right>
            <v-toolbar-title>Wagering.gg</v-toolbar-title>
            <v-spacer />
            <v-tooltip left>
                <template v-slot:activator="{ on }">
                    <v-badge :content="notifications.length"
                             :value="notifications.length"
                             color="error"
                             offset-y="22"
                             offset-x="22">
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
                                    <v-list-item-subtitle><timeago :datetime="notification.date" autoUpdate /></v-list-item-subtitle>
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
    import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

    export default {
        name: "App",
        props: {
            source: String
        },
        components: {
            "login-menu": LoginMenu
        },
        data() {
            return {
                drawer: null,
                notifications: [],
                errors: [],
                dialog: false,
                hostCount: 0,
                clientCount: 0
            };
        },
        methods: {
            receiveNotifications() {
                this.$microsoft.signalr.on("GetNotification", (notification) => {
                    this.notifications.push(notification);
                });
            },
            deleteNotification(index) {
                //add to list to be sent to server when dialog closed
                this.notifications.splice(index, 1);
            },
            receiveGroups() {
                this.$microsoft.signalr.on("ReceiveGroup", (name, notification) => {
                    this.notifications.push(notification);
                    this.$microsoft.signalr.invoke("AddToGroup", name);
                });
            },
            addGroups() {
                this.$axios.get("/api/event").then(result => {
                    result.data.hostGroups.forEach(group => {
                        this.$microsoft.signalr.invoke("AddToGroup", group);
                    });
                    this.hostCount = result.data.hostGroups.length;
                });
            },
            listen() {
                this.receiveGroups();
                this.receiveNotifications();
            }
        },
        created() {
            if (this.$store.getters.isAuthenticated && !this.$route.path.includes("authentication")) {
                this.$microsoft.signalr = new HubConnectionBuilder()
                    .withUrl("/group-hub", { accessTokenFactory: () => this.$store.getters.token })
                    .configureLogging(LogLevel.Information)
                    .withAutomaticReconnect()
                    .build();
                this.$microsoft.signalr.start().then(() => {
                    this.listen();
                    this.addGroups();
                });
            }
        }
    };
</script>
