import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import axios from "./services/axios";
import "./registerServiceWorker";
import vuetify from "./plugins/vuetify";
import "./validation/validator"; 
import TimeAgo from "./services/timeAgo";

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