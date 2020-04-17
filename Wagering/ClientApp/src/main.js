import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import axios from "axios";
import "./registerServiceWorker";
import vuetify from "./plugins/vuetify";
import "./validation/validator";
import TimeAgo from "javascript-time-ago";
import en from "javascript-time-ago/locale/en";

TimeAgo.addLocale(en);
Vue.config.productionTip = false;
Vue.prototype.$axios = axios;
Vue.prototype.$microsoft = { signalr: null };
Vue.prototype.$timeAgo = new TimeAgo("en-US");

new Vue({
	store,
	router,
	vuetify,
	render: h => h(App)
}).$mount("#app");