<template>
    <v-container>
        <!--Wager Settings-->
        <v-row>
            <v-col cols="12" sm="10" md="6" class="mx-auto">
                <v-card>
                    <v-card-title>
                        Member Manager
                    </v-card-title>
                    <v-card-text>
                        <v-container>
                            <v-toolbar>
                                <v-autocomplete v-model="form.select"
                                                :loading="form.loading"
                                                :items="users"
                                                :search-input.sync="search"
                                                cache-items
                                                hide-no-data
                                                hide-details
                                                clearable
                                                label="Username"
                                                item-text="displayName"
                                                return-object></v-autocomplete>
                                <v-btn icon @click="addUser">
                                    <v-icon>mdi-account-plus</v-icon>
                                </v-btn>
                            </v-toolbar>
                        </v-container>
                    </v-card-text>
                </v-card>
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
                users: [],
                data: null,
                loading: true,
                search: null,
                form: {
                    interval: 500,
                    timer: null,
                    loading: false,
                    select: null,
                    username: null
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
                        this.users = response.data;
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
                    //move user to member list
                }
            }
        },
        created() {
            this.getData();
        }
    };
</script>