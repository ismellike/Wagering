<template>
    <v-row>
        <v-col cols="12" sm="10" md="8" class="mx-auto">
            <v-card>
                <v-card-title>
                    Register
                </v-card-title>
                <v-card-text>
                    <ValidationObserver ref="observer">
                        <v-row>
                            <v-col cols="12" sm="6">
                                <ValidationProvider rules="alpha_num|required" name="Username" v-slot="{ errors }">
                                    <v-text-field v-model="data.username"
                                                  label="Username"
                                                  :error-messages="errors"
                                                  prepend-icon="mdi-account"
                                                  type="text"></v-text-field>
                                </ValidationProvider>
                            </v-col>
                            <v-col cols="12" sm="6">
                                <ValidationProvider rules="email|required" name="Email" v-slot="{ errors }">
                                    <v-text-field v-model="data.email"
                                                  label="Email"
                                                  :error-messages="errors"
                                                  prepend-icon="mdi-email"
                                                  type="email"></v-text-field>
                                </ValidationProvider>
                            </v-col>
                            <v-col cols="12" sm="6">
                                <ValidationProvider rules="min:6|required" name="Password" v-slot="{ errors }" vid="password">
                                    <v-text-field v-model="data.password"
                                                  label="Password"
                                                  type="password"
                                                  :error-messages="errors"
                                                  prepend-icon="mdi-lock"></v-text-field>
                                </ValidationProvider>
                            </v-col>
                            <v-col cols="12" sm="6">
                                <ValidationProvider rules="required|confirmed:password" name="Confirm Password" v-slot="{ errors }">
                                    <v-text-field v-model="data.confirmPassword"
                                                  label="Confirm Password"
                                                  type="password"
                                                  :error-messages="errors"
                                                  prepend-icon="mdi-lock"></v-text-field>
                                </ValidationProvider>
                            </v-col>
                        </v-row>
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
</template>
<script>
    export default {
        data() {
            return {
                data: {
                    username: null,
                    email: null,
                    password: null,
                    confirmPassword: null
                },
                errors: []
            }
        },
        methods: {
            submit() {
                console.log(this.$refs.observer);
                this.$refs.observer.validate().then(result => {
                    if (result) {
                        this.$axios.post("/api/account", this.data).then(response => {
                            if (response.status == 200) {
                                this.$router.push({
                                    path: "/authentication/login"
                                });
                            }
                        });
                    }
                });
            }
        }
    };
</script>