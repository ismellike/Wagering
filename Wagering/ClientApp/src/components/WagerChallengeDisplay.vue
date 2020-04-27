<template>
    <v-card>
        <toolbar dense color="accent">
            <v-toolbar-title>{{ hostsString(challenge.hosts) }}</v-toolbar-title>
            <v-spacer />
            <slot name="button"></slot>
            <HostsMenu v-if="!ignoreHosts" :hosts="challenge.hosts" />
        </toolbar>
        <v-card-text>
        </v-card-text>
        <v-card-actions>
            <timeago class="caption" since="challenge.date" :auto-update="60"></timeago>
        </v-card-actions>
    </v-card>
</template>
<script>
    import HostsMixin from "@/mixins/HostsString.js";
    import HostsMenu from "@/components/HostsMenu";
    export default {
        components: {
            HostsMenu
        },
        mixins: [HostsMixin],
        props: {
            challenge: {
                required: true
            },
            ignoreHosts: {
                type: Boolean,
                default: false
            }
        }
    };
</script>