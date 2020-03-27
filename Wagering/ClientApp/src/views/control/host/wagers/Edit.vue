<template>
    <v-container>
        <!--Wager Settings-->
        <v-row>
            <v-col cols="12" sm="10" md="8" class="mx-auto">
                <v-data-table :headers="form.headers" :items="data.hosts" hide-default-footer>
                    <template v-slot:top>
                        <v-toolbar>
                            <v-toolbar-title>Member Manager</v-toolbar-title>
                            <v-spacer></v-spacer>
                            <v-dialog v-model="form.newDialog" max-width="500px">
                                <template v-slot:activator="{ on }">
                                    <v-btn color="deep-purple" v-on="on">New Item</v-btn>
                                </template>
                                <v-card>
                                    <v-card-title>
                                        Add User
                                    </v-card-title>
                                    <v-card-text>
                                        <v-row>
                                            <v-col cols="12" sm="6">
                                                <v-autocomplete v-model="form.select"
                                                                :loading="form.loading"
                                                                :items="form.users"
                                                                :search-input.sync="search"
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
                                                <v-text-field v-model="form.percentage"
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
                            <v-dialog v-model="form.editDialog" max-width="500px">
                                <v-card>
                                    <v-card-title>
                                        Edit User
                                    </v-card-title>
                                    <v-card-text>
                                        <v-container>
                                            <v-text-field disabled label="Username" :value="form.editedItem.userDisplayName"></v-text-field>
                                        </v-container>
                                    </v-card-text>

                                    <v-card-actions>
                                        <v-spacer></v-spacer>
                                        <v-btn text @click="closeEdit">Cancel</v-btn>
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
                        <v-icon small
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
                </v-data-table>
            </v-col>
        </v-row>
        <!--Member Section-->
        <!--Winning Split-->
    </v-container>
</template>
<script>
    export default {
        data() {
            return {
                id: this.$route.params.id,
                data: {
                    hosts: []
                },
                loading: true,
                search: null,
                form: {
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
                    users: [],
                    interval: 500,
                    timer: null,
                    loading: false,
                    select: null,
                    username: null,
                    percentage: 50,
                    editedIndex: -1,
                    editedItem: {
                        userDisplayName: '',
                        approved: false,
                        percentage: 0
                    },
                    defaultItem: {
                        userDisplayName: '',
                        approved: false,
                        percentage: 0

                    },
                    newDialog: false,
                    editDialog: false
                }
            };
        },
        watch: {
            search(val) {
                clearTimeout(this.form.timer);
                if (val && val.trim() && val !== this.form.select && this.form.username != val) {
                    this.form.username = val;
                    this.form.loading = true;
                    this.form.timer = setTimeout(this.getUsers, this.form.interval);
                }
                else {
                    clearTimeout(this.form.timer);
                    this.form.loading = false;
                }
            },
        },
        methods: {
            getUsers() {
                this.$axios.get("/api/profile/search/" + this.form.username).then(response => {
                    if (response.status == 200) {
                        this.form.users = response.data;
                    }
                    this.form.loading = false;
                });
            },
            getData() {
                //for wager data
                this.loading = true;
                this.$axios.get("/api/wagers/" + this.id).then(response => {
                    if (response.status == 200) {
                        //set data
                        this.data = response.data;
                    }
                    this.loading = false;
                });
            },
            addUser() {
                if (this.form.select) {
                    //move user to member list with some defaults
                    //push to server
                }
            },
            editUser(item) {
                //get index of user
                console.log(item);
                this.form.editDialog = true;
                this.form.editedItem = Object.assign({}, item)
            },

            deleteUser(item) {
                //get index of user
                if (confirm('Are you sure you want to remove this user?')) {
                    //remove user from list
                    //send data to server for deletion
                }
            },
            closeEdit() {
                this.form.editDialog = false
                setTimeout(() => {
                    this.form.editedItem = Object.assign({}, this.form.defaultItem)
                    this.form.editedIndex = -1
                }, 300);
            },
            closeNew() {
                this.form.newDialog = false;
            }
        },
        created() {
            this.getData();
        }
    };
</script>