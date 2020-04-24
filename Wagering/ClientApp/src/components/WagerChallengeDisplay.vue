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
            <span class="caption">
                {{ $timeAgo.format(new Date(challenge.date)) }}
            </span>
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