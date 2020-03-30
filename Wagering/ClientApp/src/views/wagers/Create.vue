<template>
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
                <v-card-title>Create Wager</v-card-title>
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
                wager: {
                    gameName: this.$route.params.game.toLowerCase(),
                    minimumWager: null,
                    maximumWager: null,
                    description: null
                },
                errors: []
            };
        },
        methods: {
            submit() {
                this.$refs.observer.validate().then(response => {
                    if (response) {
                        this.postWager();
                    }
                });
            },
            postWager() {
                this.$axios.post("/api/wagers", this.wager).then(response => {
                    //send to wager view if successful or show corresponding server error messages
                    if (response.status == 200) {
                        this.$router.push({
                            name: "wager_edit",
                            params: { id: response.data }
                        });
                    } else {
                    }
                });
            }
        }
    };
</script>