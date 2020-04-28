<template>
    <v-card>
        <v-card-title>
            Notifications
        </v-card-title>
        <v-card-text>
            <v-list v-if="notifications && notifications.length > 0" two-line>
                <v-list-item v-for="notification in notifications" :key="notification.id">
                    <v-list-item-content>
                        <v-list-item-title>
                            {{ notification.message }}
                        </v-list-item-title>
                        <v-list-item-subtitle><timeago :datetime="notification.date" autoUpdate /></v-list-item-subtitle>
                    </v-list-item-content>
                </v-list-item>
            </v-list>
            <template v-else>
                There's currently no notifications.
            </template>
        </v-card-text>
    </v-card>
</template>
<script>
    export default {
        props: {
            notifications: {
                required: true
            }
        }
    };
</script>
