<template>
    <v-container>
        <v-row>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
                    <v-card>
                        <v-card-title>Members</v-card-title>
                        <v-card-text>
                            <v-data-table :headers="headers" :items="wager.hosts" hide-default-footer>
                                <!--v-slot username prepend crown if is owner-->
                                <template v-slot:item.approved="{ item }">
                                    <v-simple-checkbox v-model="item.approved" disabled></v-simple-checkbox>
                                </template>
                                <template v-slot:item.percentage="{ item }">
                                    <v-progress-circular :value="item.percentage" class="overline">
                                        {{ item.percentage }}
                                    </v-progress-circular>
                                </template>
                            </v-data-table>
                        </v-card-text>
                    </v-card>
                </v-skeleton-loader>
            </v-col>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
                    <v-card>
                        <v-card-title>Wager</v-card-title>
                        <v-card-text>
                            <WagerInfoDisplay :wager="wager" />
                        </v-card-text>
                        <v-card-actions>
                            <v-spacer />
                            <span class="caption">
                                {{ $timeAgo.format(new Date(wager.date)) }}
                            </span>
                        </v-card-actions>
                    </v-card>
                </v-skeleton-loader>
            </v-col>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
                    <v-card>
                        <v-card-title>Challenges</v-card-title>
                        <v-card-text>

                        </v-card-text>
                    </v-card>
                </v-skeleton-loader>
            </v-col>
        </v-row>
    </v-container>
</template>
<script>
    import WagerInfoDisplay from "@/components/WagerInfoDisplay";
    export default {
        components: {
            WagerInfoDisplay
        },
        data() {
            return {
                wager: {
                    hosts: [],
                    description: null
                },
                headers: [
                    {
                        text: 'Username',
                        align: 'start',
                        value: 'user.userName',
                    },
                    { text: 'Percentage', value: 'percentage' },
                    { text: 'Approved', value: 'approved' }
                ],
                loading: true,
                errors: []
            };
        },
        methods: {
            getData() {
                this.$axios.get("/api/wager/host/" + this.$route.params.id).then(result => {
                    this.wager = result.data;
                    this.loading = false;
                }).catch(e => {
                    this.errors = e.response.data.splice();
                });
            }
        },
        computed: {
        },
        created() {
            this.getData();
        }
    };
</script>