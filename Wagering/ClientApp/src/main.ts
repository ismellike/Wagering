import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import axios from "./services/axios";
import "./registerServiceWorker";
import vuetify from "./plugins/vuetify";
import "./validation/validator";
import VueTimeago from "vue-timeago";

Vue.use(VueTimeago, {
  name: "Timeago",
  locale: "en",
  locales: {
    "en-US": require("date-fns/locale/en"),
  },
});
Vue.prototype.$axios = axios;
Vue.prototype.$microsoft = { signalr: null };

new Vue({
  store,
  router,
  vuetify,
  render: (h) => h(App),
}).$mount("#app");
