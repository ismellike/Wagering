<template>
    <v-container>
        <!--Wager Settings-->
        <!--Member Section-->
        <!--Winning Split-->
    </v-container>
</template>
<script>
    export default {
        data() {
            return {
                id: this.$route.params.id,
                users: null,
                data: null,
                form: {
                    username: null
                }
            };
        },
        methods: {
            getUsers() {
                //for v-autocomplete to add users
                this.$axios.get("/api/profile/search/" + form.username).then(response => {
                    if (response.status == 200) {
                        this.users = response.data;
                    }
                });
            },
            getData() {
                //for wager data
                this.$axios.get("/api/wagers/" + this.id).then(response => {
                    if (response.status == 200) {
                        //set data
                        this.data = response.data;
                    }
                });
            }
        },
        created() {
            this.getData();
        }
    };
</script>