<template>
    <content-display>
        <v-row dense>
            <v-col
                cols="12"
                sm="6"
                lg="4"
                v-for="game in $games.games"
                v-bind:key="game.id"
            >
                <v-card color="accent">
                    <v-card-title class="display-1 keep">{{
                        game.name
                    }}</v-card-title>
                    <v-card-text class="text-center">
                        <v-btn
                            class="ma-1"
                            color="secondary"
                            :to="{
                                name: 'wagers',
                                params: { game: game.normalizedName }
                            }"
                        >
                            <v-icon left>mdi-currency-usd-circle</v-icon>Wagers
                        </v-btn>
                        <v-btn
                            class="ma-1"
                            color="secondary"
                            :to="{
                                name: 'tournaments',
                                params: { game: game.normalizedName }
                            }"
                        >
                            <v-icon left>mdi-trophy</v-icon>Tournaments
                        </v-btn>
                        <v-btn class="ma-1" color="secondary">
                            <v-icon left>mdi-shield</v-icon>Leagues
                        </v-btn>
                    </v-card-text>
                </v-card>
            </v-col>
        </v-row>
    </content-display>
</template>
<script lang="ts">
import Vue from "vue";

export default Vue.extend({});
</script>
<style scoped>
.keep {
    word-break: normal;
}
</style>