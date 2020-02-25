import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import axios from "axios";
import "./registerServiceWorker";
import vuetify from "./plugins/vuetify";
import "./validation/validator";

Vue.config.productionTip = false;
Vue.prototype.$axios = axios;

new Vue({
  store,
  router,
  vuetify,
  render: h => h(App)
}).$mount("#app");