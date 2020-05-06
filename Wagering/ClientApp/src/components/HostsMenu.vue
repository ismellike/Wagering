<template>
    <v-menu>
        <template v-slot:activator="{ on }">
            <v-btn color="info" v-on="on">Hosts</v-btn>
        </template>
        <v-list>
            <v-list-item v-for="host in hosts" :key="host.id">
                <v-list-item-title>
                    <v-btn
                        color="secondary"
                        :to="{
                            name: 'user_view',
                            params: { name: host.user.userName },
                        }"
                        class="ma-1"
                        >{{ host.user.userName }}</v-btn
                    >
                </v-list-item-title>
            </v-list-item>
        </v-list>
    </v-menu>
</template>
<script lang="ts">
    import Vue from "vue";

    export default Vue.extend({
        props: {
            hosts: {
                required: true,
            },
        },
    });
</script>
