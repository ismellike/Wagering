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
                                                <v-text-field v-model="form.user.percentage"
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
                                        <v-row>
                                            <v-col cols="12" sm="6">
                                                <v-text-field disabled label="Username" :value="form.user.userDisplayName"></v-text-field>
                                            </v-col>
                                            <v-spacer />
                                            <v-col cols="6" sm="3">
                                                <v-text-field v-model="form.user.percentage"
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
                    <template v-slot:body.append>
                        <tr>
                            <th>
                                Total:
                            </th>
                            <td>
                                <v-progress-circular :value="getTotalPercentage" class="overline">
                                    {{ getTotalPercentage }}
                                </v-progress-circular>
                            </td>
                            <td></td>
                            <td>
                                <v-btn small text @click="normalize">
                                    Normalize
                                </v-btn>
                            </td>
                        </tr>
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
                    index: -1,
                    user: {
                        userDisplayName: '',
                        approved: false,
                        percentage: 50
                    },
                    defaultUser: {
                        userDisplayName: '',
                        approved: false,
                        percentage: 50

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
        computed: {
            getTotalPercentage() {
                var s = 0;
                this.data.hosts.forEach(item => {
                    s += parseInt(item.percentage);
                });
                return s;
            }
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
                    const username = this.form.select.displayName;
                    if (!this.data.hosts.some(x => { return x.userDisplayName == username })) {
                        this.data.hosts.push({
                            userDisplayName: username,
                            approved: false,
                            percentage: 0
                        });
                        //push to server
                    }

                    this.form.newDialog = false;
                    this.form.select = null;
                }
            },
            saveUser() {
                Object.assign(this.data.hosts[this.form.index], this.form.user);
                this.closeEdit();
            },
            editUser(item) {
                this.form.index = this.data.hosts.indexOf(item);
                this.form.editDialog = true;
                this.form.user = Object.assign({}, item)
            },

            deleteUser(item) {
                const index = this.data.hosts.indexOf(item);
                if (confirm('Are you sure you want to remove this user?')) {
                    this.data.hosts.splice(index, 1);
                    //send data to server for deletion
                }
            },
            closeEdit() {
                this.form.editDialog = false
                setTimeout(() => {
                    this.form.user = Object.assign({}, this.form.defaultUser)
                    this.form.index = -1
                }, 300);
            },
            closeNew() {
                this.form.newDialog = false;
            },
            normalize() {
                const count = this.data.hosts.length;
                this.data.hosts.forEach(item => {
                    item.percentage = Math.floor(100 / count);
                });
            }
        },
        created() {
            this.getData();
        }
    };
</script>