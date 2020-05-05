<template>
    <v-container class="mb-auto">
        <!--Need to change from tabs to nav bar-->
        <!--Split into wagers/tournaments/leagues-->
        <v-container>
            <h1 class="text-center">Client Panel</h1>
        </v-container>
        <v-tabs grow show-arrows optional color="secondary">
            <v-tab to="/client/wagers">Wagers</v-tab>
            <v-tab to="/client/tournaments">Tournaments</v-tab>
            <v-tab to="/client/leagues">Leagues</v-tab>
        </v-tabs>
        <router-view></router-view>
    </v-container>
</template>
<script lang="ts">
    import Vue from "vue";
    export default Vue.extend({});
</script>
