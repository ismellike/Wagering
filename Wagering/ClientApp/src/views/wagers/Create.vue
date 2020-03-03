<template>
  <v-container>
    <ValidationObserver ref="observer">
      <v-row>
        <v-col cols="12" sm="6" class="mx-auto">
          <v-textarea v-model="wager.description" label="Description"></v-textarea>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="12" sm="6" class="mx-auto">
          <ValidationProvider
            rules="less_than:@maxWager|min_value:.001"
            vid="minWager"
            name="Minimum Wager"
            v-slot="{ errors }"
          >
            <v-text-field
              v-model="wager.minimumWager"
              label="Minimum Wager"
              type="number"
              :error-messages="errors"
            ></v-text-field>
          </ValidationProvider>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="12" sm="6" class="mx-auto">
          <ValidationProvider
            rules="greater_than:@minWager|min_value:.001"
            vid="maxWager"
            name="Maximum Wager"
            v-slot="{ errors }"
          >
            <v-text-field
              v-model="wager.maximumWager"
              label="Maximum Wager"
              type="number"
              :error-messages="errors"
            ></v-text-field>
          </ValidationProvider>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="12" sm="6" class="text-right">
          <v-btn color="green" v-on:click="submit" class="ma-1">Search</v-btn>
        </v-col>
      </v-row>
    </ValidationObserver>
  </v-container>
</template>
<script>
import { ValidationObserver } from "vee-validate";
export default {
  components: {
    ValidationObserver
  },
  data() {
    return {
      wager: {
        gameName: this.$route.params.game.toLowerCase(),
        minimumWager: null,
        maximumWager: null,
        description: null
      },
      errors: []
    };
  },
  methods: {
    submit() {
      this.$refs.observer.validate().then(response => {
        if (response) {
          this.postWager();
        }
      });
    },
    postWager() {
      console.log(this.$axios.defaults.headers.common["Authorization"]);
      this.$axios.post("/api/wagers", this.wager).then(response => {
        //send to wager view if successful or show corresponding server error messages
        console.log(response);
        if (response.status == 200) {
          this.$router.push({
            name: "wager_edit",
            params: { game: this.wager.gameName, id: response.data }
          });
        } else {
        }
      });
    }
  }
};
</script>