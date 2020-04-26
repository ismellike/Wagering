<template>
  <v-container>
    <v-row>
      <v-col cols="12" sm="10" md="8" class="mx-auto">
        <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
          <WagerHostsDisplay :hosts="wager.hosts">
            <template v-if="!hasAccepted" v-slot:actions>
              <v-spacer />
              <v-btn color="success" @click="accept">Accept</v-btn>
              <v-btn color="error" @click="decline">Decline</v-btn>
            </template>
          </WagerHostsDisplay>
        </v-skeleton-loader>
      </v-col>
      <v-col cols="12" sm="10" md="8" class="mx-auto">
        <v-skeleton-loader :loading="loading" type="card" transition="scale-transition">
          <v-card>
            <v-card-title>Wager</v-card-title>
            <v-card-text>
              <WagerInfoDisplay :wager="wager" />
            </v-card-text>
            <v-card-actions>
              <v-spacer />
              <span class="caption">{{ $timeAgo.format(new Date(wager.date)) }}</span>
            </v-card-actions>
          </v-card>
        </v-skeleton-loader>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import WagerInfoDisplay from "@/components/WagerInfoDisplay";
import WagerHostsDisplay from "@/components/WagerHostsDisplay";
export default {
  components: {
    WagerInfoDisplay,
    WagerHostsDisplay
  },
  data() {
    return {
      wager: {
        hosts: [],
        description: null
      },
      loading: true,
      errors: []
    };
  },
  methods: {
    getData() {
      this.$axios
        .get("/api/wager/host/" + this.$route.params.id)
        .then(result => {
          this.wager = result.data;
          this.loading = false;
        })
        .catch(e => {
          this.errors = e.response.data.splice();
        });
    },
    accept() {
      this.$axios
        .post("/api/bid/wager/accept", this.userBid.id)
        .then(() => {
          this.$microsoft.signalr.invoke(
            "NotifyGroup",
            "wager_" + this.$route.params.id,
            {
              message:
                this.$store.state.account.username + " has accepted the wager.",
              isRead: false,
              link: this.$route.path
            }
          );
        })
        .catch(e => {
          this.errors = e.response.data.splice();
        });
    },
    decline() {
      this.$axios
        .post("/api/bid/wager/decline", this.userBid.id)
        .then(() => {
          this.$microsoft.signalr.invoke(
            "NotifyGroup",
            "wager_" + this.$route.params.id,
            {
              message:
                this.$store.state.account.username + " has declined the wager.",
              isRead: false,
              link: this.$route.path
            }
          );
        })
        .catch(e => {
          this.errors = e.response.data.splice();
        });
    }
  },
  computed: {
    userBid() {
      return this.wager.hosts.find(host => {
        return host.user.userName == this.$store.state.account.username;
      });
    },
    hasAccepted() {
      const user = this.userBid;
      if (!user) return false;
      return user.approved;
    }
  },
  created() {
    this.getData();
  }
};
</script>