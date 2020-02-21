<template>
  <v-container>
    <div v-if="profile == null">
      <p v-if="error!=null" class="display-1">{{error}}</p>
      <v-skeleton-loader v-else type="card" />
    </div>
    <div v-else>
      <v-card></v-card>
    </div>
  </v-container>
</template>
<script>
export default {
  data() {
    return {
      name: this.$route.params.name,
      profile: null,
      error: null
    };
  },
  methods: {
    getProfile() {
      this.$axios
        .get("/api/profile/" + this.name)
        .then(response => {
          if (response.status == 200) {
            console.log(response.data);
            this.profile = response.data;
            this.error = null;
          }
        })
        .catch(() => {
          this.error = this.name + " is not a valid user.";
        });
    }
  },
  created() {
    this.getProfile();
  }
};
</script>