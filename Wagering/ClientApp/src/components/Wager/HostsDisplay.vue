<template>
    <v-card>
        <v-card-title>Members</v-card-title>
        <v-card-text>
            <v-data-table :headers="headers" :items="hosts" hide-default-footer>
                <!--v-slot username prepend crown if is owner-->
                <template v-slot:item.approved="{ item }">
                    <v-simple-checkbox
                        v-model="item.approved"
                        disabled
                    ></v-simple-checkbox>
                </template>
                <template v-slot:item.payablePt="{ item }">
                    <v-progress-circular
                        :value="item.payablePt"
                        class="overline"
                        >{{ item.payablePt }}</v-progress-circular
                    >
                </template>
                <template v-slot:item.receivablePt="{ item }">
                    <v-progress-circular
                        :value="item.receivablePt"
                        class="overline"
                        >{{ item.receivablePt }}</v-progress-circular
                    >
                </template>
            </v-data-table>
        </v-card-text>
        <v-card-actions>
            <slot name="actions"></slot>
        </v-card-actions>
    </v-card>
</template>
<script>
export default {
    props: {
        hosts: {
            required: true
        }
    },
    data() {
        return {
            headers: [
                {
                    text: "User Name",
                    align: "start",
                    value: "profile.displayName"
                },
                { text: "Payable (%)", value: "payablePt" },
                { text: "Receivable (%)", value: "receivablePt" },
                { text: "Approved", value: "approved" }
            ]
        };
    }
};
</script>