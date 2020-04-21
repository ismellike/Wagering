<template>
    <v-tabs grow show-arrows color="secondary">
        <!--Member invitations sent here and confirm send is shown when available-->
        <v-tab>Pending</v-tab>
        <!--Item is confirmed and button here to vote for winner/report-->
        <v-tab>Confirmed</v-tab>
        <!--Results view-->
        <v-tab>Completed</v-tab>
        <v-tab-item>
            <v-container>
                <!--pending-->
                <v-row dense v-for="wager in pending" :key="wager.id">
                    <v-col>
                        <v-container>
                            <WagerDisplay :wager="wager" :code="2" />
                        </v-container>
                    </v-col>
                </v-row>
            </v-container>
        </v-tab-item>
        <v-tab-item>
            <v-container>
                <!--confirmed-->
                <v-row dense v-for="wager in confirmed" :key="wager.id">
                    <v-col>
                        <v-container>
                            <WagerDisplay :wager="wager" :code="2" />
                        </v-container>
                    </v-col>
                </v-row>
            </v-container>
        </v-tab-item>
        <v-tab-item>
            <v-container>
                <!--completed-->
                <v-row dense v-for="wager in completed" :key="wager.id">
                    <v-col>
                        <v-container>
                            <WagerDisplay :wager="wager" :code="2" />
                        </v-container>
                    </v-col>
                </v-row>
            </v-container>
        </v-tab-item>
    </v-tabs>
</template>
<script>
    import WagerDisplay from "@/components/WagerDisplay";
    export default {
        components: {
            WagerDisplay
        },
        data() {
            return {
                pending: [],
                confirmed: [],
                completed: [],
                errors: []
            };
        },
        created() {
            this.$axios.get("/api/wager/host").then(response => {
                response.data.forEach(item => {
                    if (item.status == 0) {
                        this.pending.push(item);
                    } else if (item.status == 1) {
                        this.confirmed.push(item);
                    }
                    else if (item.status == 2) {
                        this.completed.push(item);
                    }
                });
            }).catch(e => {
                this.errors = e.response.data.splice();
            });
        }
    };
</script>