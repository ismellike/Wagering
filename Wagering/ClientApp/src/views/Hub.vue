<template>
    <v-container>
        <v-row dense>
            <v-col cols="12" sm="6" lg="4">
                <v-card color="accent">
                    <v-card-title class="display-1">Fortnite</v-card-title>
                    <v-card-text>
                        <v-btn class="ma-1" color="secondary" :to="{ name: 'wagers', params: { game: 'fortnite' }}">
                            <v-icon left>mdi-currency-usd-circle</v-icon>Wagers
                        </v-btn>
                        <v-btn class="ma-1" color="secondary" :to="{ name: 'tournaments', params: { game: 'fortnite' }}">
                            <v-icon left>mdi-trophy</v-icon>Tournaments
                        </v-btn>
                        <v-btn class="ma-1" color="secondary">
                            <v-icon left>mdi-shield</v-icon>Leagues
                        </v-btn>
                    </v-card-text>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>
<script>
    export default {};
</script>