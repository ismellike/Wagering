<template>
    <v-container>
        <p v-for="error in errors" class="body-1 error--text">
            {{ error }}
        </p>
    </v-container>
</template>
<script>
    export default {
        props: {
            errors: {
                required: true
            }
        }
    };
</script>