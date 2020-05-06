<template>
    <v-container>
        <p
            v-for="(error, i) in errors"
            v-bind:key="i"
            class="body-1 error--text"
        >
            {{ error }}
        </p>
    </v-container>
</template>
<script lang="ts">
    import Vue from "vue";

    export default Vue.extend({
        props: {
            errors: {
                required: true,
            },
        },
    });
</script>
