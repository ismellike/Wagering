<template>
  <v-card>
    <v-card-title>Notifications</v-card-title>
    <v-card-text>
      <v-list v-if="notifications && notifications.length > 0" two-line>
        <v-list-item v-for="item in notifications" :key="item.id">
          <v-list-item-content>
            <v-list-item-title>{{ item.notification.message }}</v-list-item-title>
            <v-list-item-subtitle>
              <timeago :datetime="item.notification.date" autoUpdate />
            </v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
      </v-list>
      <template v-else>There's currently no notifications.</template>
    </v-card-text>
  </v-card>
</template>
<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  props: {
    notifications: {
      required: true
    }
  }
});
</script>
