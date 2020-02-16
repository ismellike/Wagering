<template>
  <div class="hero-body is-block">
    <div class="container">
      <h1 class="title has-text-centered">Wagers</h1>
      <div class="level is-mobile">
        <div class="level-left">
          <div class="level-item">
            <h4 class="subtitle">Page {{ query.page }}</h4>
          </div>
        </div>
        <div class="level-right">
          <div class="level-item pointer" v-on:click="toggleFilter()">
            <span>Filter</span>
            <span class="icon">
              <img v-if="showFilter" src="@/assets/icons/expand_less.svg" />
              <img v-else src="@/assets/icons/expand_more.svg" />
            </span>
          </div>
        </div>
      </div>
      <div v-if="showFilter">
        <div class="columns">
          <div class="column">
            <div class="field">
              <label class="label" for="username">Search Username:</label>
              <div class="control has-icons-left">
                <input type="text" id="username" class="input" v-bind="query.username" />
                <span class="icon is-left">
                  <img src="@/assets/icons/account.svg" />
                </span>
              </div>
            </div>
          </div>
          <div class="column">
            <div class="field">
              <label class="label" id="count">Player Count:</label>
              <div class="control has-icons-left">
                <input type="number" id="count" class="input" v-bind="query.playerCount" />
                <span class="icon is-left">
                  <img src="@/assets/icons/people.svg" />
                </span>
              </div>
            </div>
          </div>
          <div class="column">
            <div class="field">
              <label class="label" id="minimum">Minimum Wager:</label>
              <div class="control has-icons-left">
                <input type="number" id="minimum" class="input" v-bind="query.minimumWager" />
                <span class="icon is-left">
                  <img src="@/assets/icons/lumens.png" />
                </span>
              </div>
            </div>
          </div>
          <div class="column">
            <div class="field">
              <label class="label" id="maximum">Maximum Wager:</label>
              <div class="control has-icons-left">
                <input type="number" id="maximum" class="input" v-bind="query.maximumWager" />
                <span class="icon is-left">
                  <img src="@/assets/icons/lumens.png" />
                </span>
              </div>
            </div>
          </div>
        </div>
        <div class="level is-mobile mb-1">
          <div class="level-left"></div>
          <div class="level-right">
            <div class="level-item">
              <div class="field">
                <input type="checkbox" id="closed" class="switch" v-bind="query.showClosed" />
                <label for="closed">Show Closed</label>
              </div>
            </div>
            <div class="level-item">
              <button
                type="submit"
                :disabled="isLocked"
                class="button is-primary"
                v-on:click="getWagers()"
              >Submit</button>
            </div>
          </div>
        </div>
      </div>
      <Loading v-if="isLoading" />
      <div v-else>
        <h3
          v-if="wagers.length == 0"
          class="subtitle"
        >There's no wagers at the moment. Be the first to take on a challenge.</h3>
        <div v-else>
          <div v-for="wager in wagers" v-bind:key="wager.id">
            <WagerDisplay :wager="wager" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Loading from "../components/Loading";
import WagerDisplay from "../components/WagerDisplay";
export default {
  components: {
    Loading
  },
  props: {
    game: {
      type: String,
      required: true
    }
  },
  data() {
    return {
      query: {
        username: null,
        game: this.game.toLowerCase(),
        page: 1,
        playerCount: null,
        showClosed: false,
        minimumWager: null,
        maximumWager: null
      },
      wagers: [],
      totalPages: 0,
      showFilter: false,
      isLocked: false,
      isLoading: true,
      errors: []
    };
  },
  methods: {
    toggleFilter() {
      this.showFilter = !this.showFilter;
    },
    async previous() {
      this.query.page--;
      await getWagers();
    },
    async next() {
      this.query.page++;
      await getWagers();
    },
    async getWagers() {
      this.isLocked = true;
      //validate query
      //api call here
      const api = "/api/wagers/-1";
      this.$axios.get(api).then(response => console.log(response));
      this.isLocked = false;
    }
  },
  async created() {
    await this.getWagers();
    this.isLoading = false;
  }
};
</script>