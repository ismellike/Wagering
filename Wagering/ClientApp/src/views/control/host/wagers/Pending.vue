<template>
    <v-row>
        <v-col cols="12" sm="10" md="8" class="mx-auto">
            <v-data-table :headers="headers" :items="wager.hosts" hide-default-footer>
                <template v-slot:top>
                    <v-toolbar>
                        <v-toolbar-title>Members</v-toolbar-title>
                        <v-spacer></v-spacer>
                        <template v-if="!hasAccepted">
                            <v-btn color="green" @click="accept" class="mr-2">Accept</v-btn>
                            <v-btn color="red" @click="decline">Decline</v-btn>
                        </template>
                    </v-toolbar>
                </template>
                <!--v-slot username prepend crown if is owner-->
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
                        {{ wager.description }}
                    </v-container>
                </template>
            </v-data-table>
        </v-col>
    </v-row>
</template>
<script>
    export default {
        data() {
            return {
                wager: {
                    description: null
                },
                headers: [
                    {
                        text: 'Username',
                        align: 'start',
                        value: 'userDisplayName',
                    },
                    { text: 'Percentage', value: 'percentage' },
                    { text: 'Approved', value: 'approved' }
                ]
            };
        },
        methods: {
            getData() {
                this.$axios.get("/api/wagers/" + this.$route.params.id).then(result => {
                    if (result.status == 200) {
                        this.wager = result.data;
                    }
                });
            },
            accept() {

            },
            decline() {

            }
        },
        computed: {
            hasAccepted() {
                return false;
            }
        },
        created() {
            this.getData();
        }
    };
</script>