<template>
    <v-app id="app">
        <v-navigation-drawer
            v-model="drawer"
            app
            clipped
            right
            disable-resize-watcher
            disable-route-watcher
            height="100%"
        >
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
                    <v-list-item to="/control" link>
                        <v-list-item-action>
                            <v-badge
                                :content="groupCount"
                                :value="groupCount > 0"
                                offset-x="10"
                                offset-y="10"
                                color="error"
                            >
                                <v-icon>mdi-clipboard</v-icon>
                            </v-badge>
                        </v-list-item-action>

                        <v-list-item-content>
                            <v-list-item-title>Control Panel</v-list-item-title>
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
            <notifications-display :notifications="notifications" />
            <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
        </v-app-bar>
        <v-content>
            <v-container
                v-if="$store.getters.isInitialized"
                fluid
                class="full-height"
            >
                <router-view />
            </v-container>
        </v-content>
        <v-footer inset clipped-right app>
            <v-btn href="https://discord.gg/HmmVMs2" target="_blank" icon>
                <v-icon dense>mdi-discord</v-icon>
            </v-btn>
            <v-btn
                href="https://www.instagram.com/wagering.gg"
                target="_blank"
                icon
            >
                <v-icon dense>mdi-instagram</v-icon>
            </v-btn>
            <v-btn href="https://twitter.com/WageringGG" target="_blank" icon>
                <v-icon dense>mdi-twitter</v-icon>
            </v-btn>
            <v-spacer />2020 - Wagering.gg
        </v-footer>
    </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import LoginMenu from "@/components/LoginMenu.vue";
import NotifcationsDisplay from "@/components/NotificationDisplay.vue";
import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

export default Vue.extend({
    name: "App",
    props: {
        source: String
    },
    components: {
        "login-menu": LoginMenu,
        "notifications-display": NotifcationsDisplay
    },
    data() {
        return {
            drawer: false as boolean,
            notifications: [] as PersonalNotification[],
            groupCount: 0 as number
        };
    },
    methods: {
        receiveNotifications(): void {
            this.$microsoft.signalr.on(
                "GetNotification",
                (notification: PersonalNotification) => {
                    this.notifications.push(notification);
                }
            );
        },
        getNotifications(): void {
            this.$axios.get("/api/notification").then(response => {
                response.data.forEach((notification: PersonalNotification) => {
                    this.notifications.push(notification);
                });
            });
        },
        deleteNotification(index: number): void {
            //add to list to be sent to server when dialog closed
            this.notifications.splice(index, 1);
        },
        receiveGroups(): void {
            this.$microsoft.signalr.on(
                "ReceiveGroup",
                (name: string, notification: PersonalNotification) => {
                    this.notifications.push(notification);
                    this.$microsoft.signalr.invoke("AddToGroup", name);
                }
            );
        },
        addGroups(): void {
            this.$axios.get("/api/group").then(response => {
                response.data.forEach((group: string) => {
                    this.$microsoft.signalr.invoke("AddToGroup", group);
                    this.groupCount++;
                });
            });
        },
        listen(): void {
            this.receiveGroups();
            this.receiveNotifications();
        }
    },
    created(): void {
        if (!this.$route.path.includes("authentication")) {
            this.$store.dispatch("init").then(result => {
                if (result) {
                    this.$microsoft.signalr = new HubConnectionBuilder()
                        .withUrl("/group-hub", {
                            accessTokenFactory: () => this.$store.getters.token
                        })
                        .configureLogging(LogLevel.Information)
                        .withAutomaticReconnect()
                        .build();
                    this.$microsoft.signalr.start().then(() => {
                        this.listen();
                        this.addGroups();
                    });
                    this.getNotifications();
                }
            });
        }
    }
});
</script>
