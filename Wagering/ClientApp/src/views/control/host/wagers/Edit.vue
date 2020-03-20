<template>
    <v-container>

    </v-container>
</template>
<script>
    export default {
        props: {
            //id goes here
        },
        data() {
            return {
                users,
                data
            };
        },
        methods: {
            getUsers() {
                //for v-autocomplete to add users
            },
            getData() {
                //for wager data
            }
        },
        created() {
            this.getUsers();
        }
    };
</script>