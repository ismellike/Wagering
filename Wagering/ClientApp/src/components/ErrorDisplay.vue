<template>
    <v-container v-if="error">
        <span
            v-for="(errorType, i) in error.response.data.errors"
            v-bind:key="i"
        >
            <v-alert
                v-for="(error, j) in errorType"
                v-bind:key="j"
                type="error"
            >
                {{ error }}
            </v-alert>
        </span>
    </v-container>
</template>
<script lang="ts">
import Vue from "vue";

export default Vue.component("error-display", {
    props: {
        error: {
            required: true
        }
    }
});
</script>
