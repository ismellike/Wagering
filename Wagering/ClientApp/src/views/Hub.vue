<template>
  <v-container>
    <v-row dense>
      <v-col cols="12" sm="6" lg="4">
        <v-card color="accent">
          <v-card-title class="display-1">Fortnite</v-card-title>
          <v-card-actions>
            <v-btn color="secondary" class="ma-2" :to="{ name: 'wagers', params: { game: 'fortnite' }}">
              <v-icon left>mdi-coin</v-icon>Wagers
            </v-btn>
            <v-btn color="secondary" class="ma-2" :to="{ name: 'tournaments', params: { game: 'fortnite' }}">
              <v-icon left>mdi-trophy</v-icon>Tournaments
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template> 
<script>
export default {};
</script>