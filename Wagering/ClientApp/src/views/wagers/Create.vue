<template>
    <v-container>
        <h1 class="text-center">Create Wager</h1>
        <v-row>
            <v-col cols="12" md="6" class="mx-auto">
                <ValidationObserver ref="observer">
                    <v-row>
                        <v-col cols="12" sm="6">
                            <ValidationProvider rules="less_than:@maxWager|min_value:.001"
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
                            <ValidationProvider rules="greater_than:@minWager|min_value:.001"
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
                    <v-container class="text-right">
                        <v-btn color="green" v-on:click="submit">Create</v-btn>
                    </v-container>
                </ValidationObserver>
            </v-col>
        </v-row>
    </v-container>
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