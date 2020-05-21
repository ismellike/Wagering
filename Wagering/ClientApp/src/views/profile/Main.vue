<template>
    <content-display>
        <v-card>
            <v-toolbar color="accent" dark>
                <v-toolbar-title>Manage Profile</v-toolbar-title>
            </v-toolbar>
            <v-tabs vertical>
                <v-tab>
                    Public Key
                </v-tab>
                <v-tab to="/authentication/profile">Account</v-tab>
                <v-tab-item>
                    <!--Edit public key here-->
                </v-tab-item>
            </v-tabs>
        </v-card>
    </content-display>
</template>
<script lang="ts">
import Vue from "vue";
export default Vue.extend({
    methods: {
        submitKey() {}
    }
});
</script>