<template>
    <v-container>
        <v-row>
            <v-col cols="12" sm="6" md="4" class="mx-auto">
                <v-card>
                    <v-card-title>
                        Register
                    </v-card-title>
                    <v-card-text>
                        <template v-for="error in errors">
                            <v-list-item v-for="message in error" color="red" dense disabled>
                                <v-list-item-content>
                                    {{ message }}
                                </v-list-item-content>
                            </v-list-item>
                        </template>
                        <ValidationObserver ref="observer">
                            <v-container>
                                <ValidationProvider rules="alpha_num|required" name="Username" v-slot="{ errors }">
                                    <v-text-field v-model="form.username"
                                                  label="Username"
                                                  :error-messages="errors"
                                                  prepend-icon="mdi-account"
                                                  type="text"></v-text-field>
                                </ValidationProvider>
                            </v-container>
                            <v-container>
                                <ValidationProvider rules="email|required" name="Email" v-slot="{ errors }">
                                    <v-text-field v-model="form.email"
                                                  label="Email"
                                                  :error-messages="errors"
                                                  prepend-icon="mdi-email"
                                                  type="email"></v-text-field>
                                </ValidationProvider>
                            </v-container>
                            <v-container>
                                <ValidationProvider rules="min:6|required" name="Password" v-slot="{ errors }" vid="password">
                                    <v-text-field v-model="form.password"
                                                  label="Password"
                                                  type="password"
                                                  :error-messages="errors"
                                                  prepend-icon="mdi-lock"></v-text-field>
                                </ValidationProvider>
                            </v-container>
                            <v-container>
                                <ValidationProvider rules="required|confirmed:password" name="Confirm Password" v-slot="{ errors }">
                                    <v-text-field v-model="form.confirmPassword"
                                                  label="Confirm Password"
                                                  type="password"
                                                  :error-messages="errors"
                                                  prepend-icon="mdi-lock"></v-text-field>
                                </ValidationProvider>
                            </v-container>
                        </ValidationObserver>
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="deep-purple" @click="submit">
                            Submit
                        </v-btn>
                    </v-card-actions>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>
<script>
    export default {
        data() {
            return {
                form: {
                    username: null,
                    email: null,
                    password: null,
                    confirmPassword: null
                },
                errors: []
            };
        },
        methods: {
            submit() {
                this.$refs.observer.validate().then(result => {
                    if (result) {
                        this.$axios.post("/api/account", this.form).then(response => {
                            if (response.status == 200) {
                                this.$router.push({
                                    path: "/login"
                                });
                            }
                        }).catch(e => {
                            this.errors = e.response.data;
                            console.log(this.errors);
                        });
                    }
                });
            }
        }
    };
</script>