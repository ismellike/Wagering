<template>
    <v-tooltip left>
        <template v-slot:activator="{ on }">
            <v-badge
                :content="notifications.length"
                :value="notifications.length > 0"
                color="error"
                offset-y="20"
                offset-x="20"
            >
                <v-btn
                    color="warning"
                    icon
                    v-on="on"
                    @click.stop="dialog = true"
                >
                    <v-icon>mdi-bell</v-icon>
                </v-btn>
            </v-badge>
        </template>
        <span>Notifications</span>
        <v-dialog v-model="dialog" max-width="500">
            <v-card>
                <v-card-title>Notifications</v-card-title>

                <v-card-text>
                    <v-list two-line>
                        <v-list-item
                            v-for="(notification, i) in notifications"
                            :key="i"
                        >
                            <v-list-item-content>
                                <v-list-item-title>{{
                                    notification.message
                                }}</v-list-item-title>
                                <v-list-item-subtitle>
                                    <timeago
                                        :datetime="notification.date"
                                        autoUpdate
                                    />
                                </v-list-item-subtitle>
                            </v-list-item-content>
                            <v-list-item-action>
                                <template>
                                    <v-btn icon @click="deleteNotification(i)">
                                        <v-icon color="error"
                                            >mdi-delete</v-icon
                                        >
                                    </v-btn>
                                    <v-btn icon :to="notification.link">
                                        <v-icon
                                            >mdi-subdirectory-arrow-right</v-icon
                                        >
                                    </v-btn>
                                </template>
                            </v-list-item-action>
                        </v-list-item>
                    </v-list>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn text color="error" @click="dialog = false"
                        >Close</v-btn
                    >
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-tooltip>
</template>
<script lang="ts">
import Vue from "vue";
export default Vue.extend({
    props: {
        notifications: {
            required: true
        }
    },
    data() {
        return {
            dialog: false as boolean
        };
    }
});
</script>