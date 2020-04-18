<template>
    <v-card>
        <v-card-text class="text-center">
            <v-btn v-for="challenger in challenge.challengers"
                   :key="challenger.id"
                   :to="{ name:'user_view', params:{name:challenger.user.userName}}"
                   color="deep-purple"
                   class="ma-1">{{ challenger.user.userName }}</v-btn>
        </v-card-text>
        <v-card-actions>
            <v-row dense>
                <v-col cols="6">
                    <v-card>
                        <v-card-text class="subtitle-2 text-center">{{ challenge.amount }} XLM</v-card-text>
                    </v-card>
                </v-col>
                <v-col cols="6">
                    <v-card>
                        <v-card-text class="subtitle-2 text-center">
                            <v-badge color="green" icon="mdi-check" :value="challenge.isAccepted">
                                {{ $timeAgo.format(new Date(challenge.date)) }}
                            </v-badge>
                        </v-card-text>
                    </v-card>
                </v-col>
            </v-row>
        </v-card-actions>
    </v-card>
</template>
<script>
    export default {
        props: {
            data: {
                required: true
            }
        },
        data() {
            return {
                challenge: this.data
            };
        },
        created() {
        }
    };
</script>