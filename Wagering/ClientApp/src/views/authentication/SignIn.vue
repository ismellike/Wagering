<template>
    <content-display> </content-display>
</template>
<script lang="ts">
import Vue from "vue";
export default Vue.extend({
    data() {
        return {
            email: "" as string,
            password: "" as string
        };
    },
    methods: {
        post() {
            this.$axios.post("/api/account/signin", {
                username: this.email,
                password: this.password
            });
            //redirect to callback
        }
    },
    created() {
        this.post();
    }
});
</script>