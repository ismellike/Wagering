<template>
    <v-container>

    </v-container>
</template>
<script>
    export default {
        data() {
            return {
                id: this.$route.params.id,
                users: [],
                data: null
            };
        },
        methods: {
            getUsers() {
                //for v-autocomplete to add users
                this.$axios.get("/api/users/" /*+ username*/).then(response => {
                    if (response.status == 200) {
                        //set autocomplete data
                    }
                });
            },
            getData() {
                //for wager data
                this.$axios.get("/api/wagers/host/" + this.id).then(response => {
                    if (response.status == 200) {
                        //set data
                    }
                });
            }
        },
        created() {
            this.getUsers();
        }
    };
</script>