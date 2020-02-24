<template>
  <v-container>
    <v-card light>
      <v-toolbar dense dark>
        <v-toolbar-title>{{ hostsString(4) }}</v-toolbar-title>
        <v-spacer />
        <v-btn
          color="green"
          v-if="hasView"
          :to="{ name: 'wager_view', params: { game: game, id: wager.id } }"
          class="mr-2"
        >View</v-btn>
        <v-menu>
          <template v-slot:activator="{ on }">
            <v-btn color="deep-purple" v-on="on">Hosts</v-btn>
          </template>
          <v-list>
            <v-list-item v-for="host in wager.hosts" :key="host.id">
              <v-list-item-title>
                <v-btn
                  color="deep-purple"
                  :to="{ name:'profile_view', params:{name:host.userDisplayName}}"
                  class="ma-1"
                >{{ host.userDisplayName }}</v-btn>
              </v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
      </v-toolbar>
      <v-card-text class="title">{{ wager.description }}</v-card-text>
      <v-card-actions>
        <v-row dense>
          <v-col cols="12" sm="6" md="3">
            <v-card dark>
              <v-card-text
                class="subtitle-2 text-center"
              >Minimum Wager: {{ numDisplay(wager.minimumWager) }}</v-card-text>
            </v-card>
          </v-col>
          <v-col cols="12" sm="6" md="3">
            <v-card dark>
              <v-card-text
                class="subtitle-2 text-center"
              >Maximum Wager: {{ numDisplay(wager.maximumWager) }}</v-card-text>
            </v-card>
          </v-col>
          <v-col cols="12" sm="6" md="3">
            <v-card dark>
              <v-card-text class="subtitle-2 text-center">{{ wager.challengeCount }} Challenges</v-card-text>
            </v-card>
          </v-col>
          <v-col cols="12" sm="6" md="3">
            <v-card dark>
              <v-card-text class="subtitle-2 text-center">
                {{
                wager.timeAgo
                }}
              </v-card-text>
            </v-card>
          </v-col>
        </v-row>
      </v-card-actions>
    </v-card>
  </v-container>
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
