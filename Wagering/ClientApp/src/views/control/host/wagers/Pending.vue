<template>
    <v-container>
        <v-row>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-data-table :headers="headers" :items="wager.hosts" hide-default-footer>
                    <template v-slot:top>
                        <v-toolbar color="accent">
                            <v-toolbar-title>Members</v-toolbar-title>
                            <v-spacer></v-spacer>
                            <template v-if="!hasAccepted">
                                <v-btn color="success" @click="accept" class="mr-2">Accept</v-btn>
                                <v-btn color="error" @click="decline">Decline</v-btn>
                            </template>
                        </v-toolbar>
                    </template>
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
            </v-col>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-card>
                    <v-card-title>Wager Settings</v-card-title>
                    <v-card-text>
                        <v-simple-table>
                            <table>
                                <thead>
                                    <tr>
                                        <th>
                                            Description
                                        </th>
                                        <th>
                                            Minimum Wager
                                        </th>
                                        <th>
                                            Maximum Wager
                                        </th>
                                        <th>
                                            Challenge Count
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            {{wager.description}}
                                        </td>
                                        <td>
                                            {{ moneyDisplay(wager.minimumWager) }}
                                        </td>
                                        <td>
                                            {{ moneyDisplay(wager.maximumWager) }}
                                        </td>
                                        <td>
                                            {{ wager.challengeCount }}
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </v-simple-table>
                    </v-card-text>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>
<script>
    export default {
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
            },
            moneyDisplay(num) {
                if (num == null) return "-";
                return "$" + num;
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