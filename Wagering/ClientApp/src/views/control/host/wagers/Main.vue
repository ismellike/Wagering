<template>
    <v-tabs grow>
        <!--Member invitations sent here and confirm send is shown when available-->
        <v-tab>Pending</v-tab>
        <!--Item is confirmed and button here to vote for winner/report-->
        <v-tab>Confirmed</v-tab>
        <!--Results view-->
        <v-tab>Completed</v-tab>
        <v-tab-item>
            <v-container>
                <!--pending-->
            </v-container>
        </v-tab-item>
        <v-tab-item>
            <v-container>
                <!--confirmed-->
            </v-container>
        </v-tab-item>
        <v-tab-item>
            <v-container>
                <!--completed-->
            </v-container>
        </v-tab-item>
    </v-tabs>
</template>
<script>
    export default {
        data() {
            return {
                pending: null,
                confirmed: null,
                completed: null
            };
        },
        created() {
            this.$axios.get("/api/panel/host/wagers").then(response => {
                console.log(response);
                //foreach add to pending/confirmed/completed array
            });
        }
    };
</script>