<template>
  <article class="media pointer" v-on:click="toggleActive">
    <div class="media-content">
      <div class="content">
        <h5 class="subtitle">{{ question }}</h5>
      </div>
      <div v-if="isActive" class="content">
        <div class="columns">
          <div class="column is-offset-1">{{ answer }}</div>
        </div>
      </div>
    </div>
    <div class="media-right">
      <span class="icon">
        <img v-if="isActive" src="../assets/icons/expand_less.svg" />
        <img v-else src="../assets/icons/expand_more.svg" />
      </span>
    </div>
  </article>
</template>
<script>
export default {
  props: {
    question: {
      type: String,
      required: true
    },
    answer: {
      type: String,
      required: true
    }
  },
  data() {
    return {
      isActive: false
    };
  },
  methods: {
    toggleActive() {
      this.isActive = !this.isActive;
    }
  }
};
</script>