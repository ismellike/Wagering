<template>
    <v-container>
        <v-row>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
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
                    <v-card-actions v-if="!hasAccepted">
                        <v-spacer />
                        <v-btn color="success" @click="accept">Accept</v-btn>
                        <v-btn color="error" @click="decline">Decline</v-btn>
                    </v-card-actions>
                </v-card>
            </v-col>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-card>
                    <v-card-title>Wager Settings</v-card-title>
                    <v-card-text>
                        <WagerInfoDisplay :wager="wager" />
                    </v-card-text>
                </v-card>
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
                        value: 'userDisplayName',
                    },
                    { text: 'Percentage', value: 'percentage' },
                    { text: 'Approved', value: 'approved' }
                ],
                errors: []
            };
        },
        methods: {
            getData() {
                this.$axios.get("/api/wagers/" + this.$route.params.id).then(result => {
                    this.wager = result.data;
                }).catch(e => {
                    this.errors = e.response.data.splice();
                });
            },
            accept() {
                this.$axios.post("/api/wagers/accept", this.userBid.id).then(result => {
                }).catch(e => {
                    this.errors = e.response.data.splice();
                });
            },
            decline() {
                this.$axios.post("/api/wagers/decline", this.userBid.id).then(result => {
                }).catch(e => {
                    this.errors = e.response.data.splice();
                });
            }
        },
        computed: {
            userBid() {
                return this.wager.hosts.find(host => {
                    return host.userDisplayName === this.$store.state.account.username;
                });
            },
            hasAccepted() {
                const user = this.userBid;
                if (!user)
                    return false;
                return user.approved;
            }
        },
        created() {
            this.getData();
        }
    };
</script>