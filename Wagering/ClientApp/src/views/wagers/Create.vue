<template>
    <v-row>
        <v-col cols="12" sm="10" md="8" class="mx-auto">
            <v-data-table :headers="headers" :items="wager.hosts" hide-default-footer>
                <template v-slot:top>
                    <v-toolbar>
                        <v-toolbar-title>User Manager</v-toolbar-title>
                        <v-spacer></v-spacer>
                        <v-dialog v-model="newDialog" max-width="500px">
                            <template v-slot:activator="{ on }">
                                <v-btn color="deep-purple" v-on="on">Add User</v-btn>
                            </template>
                            <v-card>
                                <v-card-title>
                                    Add User
                                </v-card-title>
                                <v-card-text>
                                    <v-row>
                                        <v-col cols="12" sm="6">
                                            <v-autocomplete v-model="search.select"
                                                            :loading="search.loading"
                                                            :items="search.users"
                                                            :search-input.sync="searchEvent"
                                                            cache-items
                                                            hide-no-data
                                                            hide-details
                                                            clearable
                                                            label="Username"
                                                            item-text="displayName"
                                                            return-object>
                                            </v-autocomplete>
                                        </v-col>
                                        <v-spacer />
                                        <v-col cols="6" sm="3">
                                            <v-text-field v-model="user.percentage"
                                                          label="Percentage"
                                                          type="number"
                                                          append-icon="mdi-percent-outline"></v-text-field>
                                        </v-col>
                                    </v-row>
                                </v-card-text>

                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="deep-purple" @click="addUser">
                                        Add
                                    </v-btn>
                                    <v-btn @click="closeNew">Cancel</v-btn>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                        <v-dialog v-model="editDialog" max-width="500px">
                            <v-card>
                                <v-card-title>
                                    Edit User
                                </v-card-title>
                                <v-card-text>
                                    <v-row>
                                        <v-col cols="12" sm="6">
                                            <v-text-field disabled label="Username" :value="user.userDisplayName"></v-text-field>
                                        </v-col>
                                        <v-spacer />
                                        <v-col cols="6" sm="3">
                                            <v-text-field v-model="user.percentage"
                                                          label="Percentage"
                                                          type="number"
                                                          append-icon="mdi-percent-outline"></v-text-field>
                                        </v-col>
                                    </v-row>
                                </v-card-text>

                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="deep-purple" @click="saveUser">Save</v-btn>
                                    <v-btn @click="closeEdit">Cancel</v-btn>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                    </v-toolbar>
                </template>
                <template v-slot:item.actions="{ item }">
                    <v-icon small
                            class="mr-2"
                            @click="editUser(item)">
                        mdi-pencil
                    </v-icon>
                    <v-icon v-if="!item.isOwner"
                            small
                            @click="deleteUser(item)">
                        mdi-delete
                    </v-icon>
                </template>
                <template v-slot:item.approved="{ item }">
                    <v-simple-checkbox v-model="item.approved" disabled></v-simple-checkbox>
                </template>
                <template v-slot:item.percentage="{ item }">
                    <v-progress-circular :value="item.percentage" class="overline">
                        {{ item.percentage }}
                    </v-progress-circular>
                </template>
                <template v-slot:footer>
                    <v-container>
                        <v-row class="text-center">
                            <v-col class="overline">
                                Total:
                                <v-progress-circular :value="getTotalPercentage">
                                    {{ getTotalPercentage }}
                                </v-progress-circular>
                            </v-col>
                            <v-col>
                                <v-btn small text @click="normalize">
                                    Normalize
                                </v-btn>
                            </v-col>
                        </v-row>
                    </v-container>
                </template>
            </v-data-table>
        </v-col>
        <v-col cols="12" sm="10" md="8" class="mx-auto">
            <v-card>
                <v-card-title>Settings</v-card-title>
                <v-card-text>
                    <ValidationObserver ref="observer">
                        <v-row>
                            <v-col cols="12" sm="6">
                                <ValidationProvider rules="less_than:@maxWager|min_amount"
                                                    vid="minWager"
                                                    name="Minimum Wager"
                                                    v-slot="{ errors }">
                                    <v-text-field v-model="wager.minimumWager"
                                                  label="Minimum Wager"
                                                  type="number"
                                                  :error-messages="errors"></v-text-field>
                                </ValidationProvider>
                            </v-col>
                            <v-col cols="12" sm="6">
                                <ValidationProvider rules="greater_than:@minWager|min_amount"
                                                    vid="maxWager"
                                                    name="Maximum Wager"
                                                    v-slot="{ errors }">
                                    <v-text-field v-model="wager.maximumWager"
                                                  label="Maximum Wager"
                                                  type="number"
                                                  :error-messages="errors"></v-text-field>
                                </ValidationProvider>
                            </v-col>
                        </v-row>
                        <v-row>
                            <v-col>
                                <v-textarea v-model="wager.description" label="Description"></v-textarea>
                            </v-col>
                        </v-row>
                    </ValidationObserver>
                </v-card-text>
                <v-card-actions>
                    <v-spacer />
                    <v-btn color="green" v-on:click="submit">Create</v-btn>
                </v-card-actions>
            </v-card>
        </v-col>
    </v-row>
</template>
<script>
    import { ValidationObserver } from "vee-validate";
    export default {
        components: {
            ValidationObserver
        },
        data() {
            return {
                searchEvent: null,
                wager: {
                    gameName: this.$route.params.game.toLowerCase(),
                    minimumWager: null,
                    maximumWager: null,
                    description: null,
                    hosts: [
                        {
                            userDisplayName: this.$store.state.account.username,
                            approved: true,
                            percentage: 100,
                            isOwner: true
                        }
                    ]
                },
                search: {
                    users: [],
                    username: null,
                    interval: 500,
                    loading: false,
                    select: null,
                    timer: null
                },
                user: {
                    userDisplayName: '',
                    approved: false,
                    percentage: 50,
                    isOwner: false
                },
                defaultUser: {
                    userDisplayName: '',
                    approved: false,
                    percentage: 50,
                    isOwner: false

                },
                index: -1,
                newDialog: false,
                editDialog: false,
                headers: [
                    {
                        text: 'Username',
                        align: 'start',
                        value: 'userDisplayName',
                    },
                    { text: 'Percentage', value: 'percentage' },
                    { text: 'Approved', value: 'approved' },
                    { text: 'Actions', value: 'actions', sortable: false },
                ],
                errors: []
            };
        },
        watch: {
            searchEvent(val) {
                clearTimeout(this.search.timer);
                if (val && val.trim() && val !== this.search.select && this.search.username != val) {
                    this.search.username = val;
                    this.search.loading = true;
                    this.search.timer = setTimeout(this.getUsers, this.search.interval);
                }
                else {
                    clearTimeout(this.search.timer);
                    this.search.loading = false;
                }
            },
        },
        computed: {
            getTotalPercentage() {
                var s = 0;
                this.wager.hosts.forEach(item => {
                    s += parseInt(item.percentage);
                });
                return s;
            }
        },
        methods: {
            getUsers() {
                this.$axios.get("/api/profile/search/" + this.search.username).then(response => {
                    if (response.status == 200) {
                        this.search.users = response.data;
                    }
                }).finally(() => {
                    this.search.loading = false;
                });
            },
            addUser() {
                if (this.search.select) {
                    const username = this.search.select.displayName;
                    if (!this.wager.hosts.some(x => { return x.userDisplayName == username })) {
                        this.wager.hosts.push({
                            userDisplayName: username,
                            approved: false,
                            percentage: this.user.percentage
                        });
                        //push to server
                    }

                    this.newDialog = false;
                    this.search.select = null;
                }
            },
            saveUser() {
                Object.assign(this.wager.hosts[this.index], this.user);
                this.closeEdit();
            },
            editUser(item) {
                this.index = this.wager.hosts.indexOf(item);
                this.editDialog = true;
                this.user = Object.assign({}, item)
            },
            closeEdit() {
                this.editDialog = false
                setTimeout(() => {
                    this.user = Object.assign({}, this.defaultUser)
                    this.index = -1
                }, 300);
            },
            closeNew() {
                this.newDialog = false;
            },
            normalize() {
                const count = this.wager.hosts.length;
                this.wager.hosts.forEach(item => {
                    item.percentage = Math.floor(100 / count);
                });
            },
            submit() {
                this.$refs.observer.validate().then(response => {
                    if (response) {
                        this.postWager();
                    }
                });
            },
            postWager() {
                this.$axios.post("/api/wagers", this.wager).then(response => {
                    if (response.status == 200) {
                        //send to host_panel
                    }
                }).catch(e => {
                    this.errors = e.response.data;
                });
            }
        }
    };
</script>