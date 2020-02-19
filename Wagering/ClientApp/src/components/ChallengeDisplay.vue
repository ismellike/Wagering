<template>
  <v-card color="white" light class="my-2">
    <v-toolbar color="grey darken-3" dense dark>
      <v-btn color="green">Accept</v-btn>
      <v-spacer />
      <v-btn color="red">Decline</v-btn>
    </v-toolbar>
    <v-card-text class="title">
      <v-btn
        v-for="challenger in challenge.challengers"
        :key="challenger.id"
        :to="{ name:'account_view', params:{id:challenger.userDisplayName}}"
        color="deep-purple"
        dark
        class="ma-1"
      >{{ challenger.userDisplayName }}</v-btn>
    </v-card-text>
    <v-card-actions>
      <v-row dense>
        <v-col cols="12" sm="6">
          <v-card color="grey darken-3" dark>
            <v-card-text class="subtitle-2 text-center">{{ challenge.amount }}</v-card-text>
          </v-card>
        </v-col>
        <v-col cols="12" sm="6">
          <v-card color="grey darken-3" dark>
            <v-card-text class="subtitle-2 text-center">
              {{
              challenge.timeAgo
              }}
            </v-card-text>
          </v-card>
        </v-col>
      </v-row>
    </v-card-actions>
  </v-card>
</template>
<script>
export default {
  props: {
    data: {
      required: true
    }
  },
  data() {
    return {
      challenge: this.data
    };
  },
  methods: {},
  created() {
    console.log(this.challenge);
  }
};
</script>