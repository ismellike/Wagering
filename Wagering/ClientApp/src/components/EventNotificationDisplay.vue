<template>
    <v-card>
        <v-card-title>Notifications</v-card-title>
        <v-card-text>
            <v-list two-line>
                <v-list-item v-for="(notification, i) in notifications" :key="i">
                    <v-list-item-content>
                        <v-list-item-title>
                            {{ notification.message }}
                        </v-list-item-title>
                        <v-list-item-subtitle><timeago datetime="notification.date" autoUpdate /></v-list-item-subtitle>
                    </v-list-item-content>
                </v-list-item>
            </v-list>
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
