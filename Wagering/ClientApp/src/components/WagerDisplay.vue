<template>
  <article class="message is-dark">
    <div class="message-header">
      <p>{{ hostsString(4) }}</p>
      <router-link
        v-if="hasView"
        class="button is-small is-primary"
        :to="{ name: 'wager_view', params: { game: game, id: wager.id }}"
      >View</router-link>
    </div>
    <div class="message-body">
      <p class="content">{{ wager.description }}</p>
      <div class="level is-size-7">
        <div class="level-item">{{ wager.challengeCount }} Challenges</div>
        <div class="level-item">Minimum Wager: {{ numDisplay(wager.minimumWager) }}</div>
        <div class="level-item">Maximum Wager: {{ numDisplay(wager.maximumWager) }}</div>
        <div class="level-item">{{ wager.timeAgo }}</div>
      </div>
    </div>
  </article>
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