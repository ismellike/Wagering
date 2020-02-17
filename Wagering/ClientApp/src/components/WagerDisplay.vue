<template>
  <v-card color="white">
    <v-toolbar color="grey darken-3" window dark>
      <v-toolbar-title>{{ hostsString(4) }}</v-toolbar-title>
      <v-spacer />
      <v-btn
        color="green"
        v-if="hasView"
        :to="{ name: 'wager_view', params: { game: game, id: wager.id }}"
      >View</v-btn>
    </v-toolbar>
  </v-card>
</template>
<script>
export default {
  props: {
    game: {
      type: String,
      required: true
    },
    data: {
      required: true
    },
    hasView: {
      type: Boolean,
      default: true
    }
  },
  data() {
    return {
      wager: this.data
    };
  },
  methods: {
    hostsString(cutoff) {
      const length = this.wager.hosts.length;
      if (length > cutoff) {
        return (
          this.wager.hosts
            .splice(0, cutoff)
            .map(x => x.userDisplayName)
            .join(", ") +
          ", +" +
          (length - cutoff + 1) +
          " more..."
        );
      }
      return this.wager.hosts.map(x => x.userDisplayName).join(", ");
    },
    numDisplay(num) {
      if (num == null) return "-";
      return num;
    }
  }
};
</script>
<style scoped>
.message-body {
  color: black;
}
.message {
  margin-bottom: 1.5rem;
}
</style>