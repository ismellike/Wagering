<template>
  <v-card>
    <v-toolbar dense color="accent">
      <v-toolbar-title>{{ hostsString(wager.hosts) }}</v-toolbar-title>
      <v-spacer />
      <slot name="button"></slot>
      <hosts-menu v-if="!ignoreHosts" :hosts="wager.hosts" />
    </v-toolbar>
    <v-card-text>
      <info-display :wager="wager" />
    </v-card-text>
    <v-card-actions>
      <v-spacer />
      <timeago class="caption" :datetime="wager.date" autoUpdate />
    </v-card-actions>
  </v-card>
</template>
<script>
import InfoDisplay from "@/components/Wager/InfoDisplay";
import HostsMenu from "@/components/HostsMenu";
import HostsMixin from "@/mixins/HostsString";
export default {
  components: {
    "info-display": InfoDisplay,
    "hosts-menu": HostsMenu
  },
  mixins: [HostsMixin],
  props: {
    wager: {
      required: true
    },
    ignoreHosts: {
      type: Boolean,
      default: false
    }
  }
};
</script>
