<template>
    <v-card>
        <v-card-text class="text-center">
            <v-btn v-for="challenger in challenge.challengers"
                   :key="challenger.id"
                   :to="{ name:'profile_view', params:{name:challenger.profileDisplayName}}"
                   color="deep-purple"
                   class="ma-1">{{ challenger.profileDisplayName }}</v-btn>
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