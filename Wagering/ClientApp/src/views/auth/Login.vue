<template>
    <v-container>
        <v-row>
            <v-col cols="12" sm="6" md="4" class="mx-auto">
                <v-card>
                    <v-card-title>
                        Login
                    </v-card-title>
                    <v-card-text>
                        <template v-for="error in errors">
                            <v-list-item v-for="message in error" color="red" dense disabled>
                                <v-list-item-content>
                                    {{ message }}
                                </v-list-item-content>
                            </v-list-item>
                        </template>
                        <v-container>
                            <v-text-field v-model="form.username" label="Username" prepend-icon="mdi-account" type="text"></v-text-field>
                        </v-container>
                        <v-container>
                            <v-text-field v-model="form.password" label="Password" prepend-icon="mdi-lock" type="password"></v-text-field>
                        </v-container>
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="deep-purple" @click="login">
                            Login
                        </v-btn>
                    </v-card-actions>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>
<script>
    import AuthService, { AuthenticationResultStatus } from "@/auth/AuthService";
    export default {
        data() {
            return {
                form: {
                    username: null,
                    password: null
                },
                errors: []
            };
        },
        methods: {
            login() {
                this.$axios.post("/api/account/login", this.form).then(response => {
                    if (response.status == 200) {
                        this.authenticate();
                    }
                }).catch(e => {
                    this.errors = e.response.data;
                });
            },
            authenticate() {
                //work on this
                AuthService.signIn(null).then(result => {
                    switch (result.status) {
                        case AuthenticationResultStatus.Redirect:
                            break;
                        case AuthenticationResultStatus.Success:
                            this.addUser();
                            this.$router.push({
                                path: "/"
                            });
                            break;
                        case AuthenticationResultStatus.Fail:
                            this.errors.push(result.message);
                            break;
                        default:
                            throw new Error(`Invalid status result ${result.status}.`);
                    }
                }).catch(e => {
                    console.log(e);
                });
            },
            addUser() {
                AuthService.getUser().then(user => {
                    const accessToken = user && user.access_token;
                    const name = user && user.name;
                    if (name) {
                        var payload = {
                            username: name,
                            token: accessToken
                        }
                        this.$store.dispatch("setLogin", payload);
                    }
                }).catch(e => {
                    console.log(e);
                });
            }
        }
    };
</script>