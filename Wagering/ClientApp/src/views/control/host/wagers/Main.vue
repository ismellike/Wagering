<template>
    <v-tabs grow show-arrows>
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
                            <wager-display :wager="wager" ignoreHosts>
                                <template v-slot:button>
                                    <v-btn
                                        color="secondary"
                                        :to="{
                                            name: 'wager_pending',
                                            params: { id: wager.id }
                                        }"
                                        >View</v-btn
                                    >
                                </template>
                            </wager-display>
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
                            <wager-display :wager="wager" ignoreHosts>
                                <template v-slot:button>
                                    <v-btn
                                        color="secondary"
                                        :to="{
                                            name: 'wager_confirmed',
                                            params: { id: wager.id }
                                        }"
                                        >View</v-btn
                                    >
                                </template>
                            </wager-display>
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
                            <wager-display :wager="wager" ignoreHosts>
                                <template v-slot:button>
                                    <v-btn
                                        color="secondary"
                                        :to="{
                                            name: 'wager_completed',
                                            params: { id: wager.id }
                                        }"
                                        >View</v-btn
                                    >
                                </template>
                            </wager-display>
                        </v-container>
                    </v-col>
                </v-row>
            </v-container>
        </v-tab-item>
    </v-tabs>
</template>
<script lang="ts">
import Vue from "vue";
import WagerDisplay from "@/components/Wager/WagerDisplay.vue";
import { Status } from "@/models/enums";

export default Vue.extend({
    components: {
        "wager-display": WagerDisplay
    },
    data() {
        return {
            pending: [] as Wager[],
            confirmed: [] as Wager[],
            completed: [] as Wager[],
            errors: [] as Wager[]
        };
    },
    created() {
        this.$axios.get("/api/wager/control").then(response => {
            response.data.forEach((item: Wager) => {
                switch (item.status) {
                    case Status.Created:
                        this.pending.push(item);
                        break;
                    case Status.Confirmed:
                        this.confirmed.push(item);
                        break;
                }
            });
        });
    }
});
</script>
