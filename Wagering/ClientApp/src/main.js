import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import axios from "axios";
import "./registerServiceWorker";
import vuetify from "./plugins/vuetify";
import "./validation/validator";
import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

Vue.config.productionTip = false;
Vue.prototype.$axios = axios;
Vue.prototype.$signalr = new HubConnectionBuilder()
	.withUrl("/group-hub")
	.configureLogging(LogLevel.Information)
	.build();

new Vue({
	store,
	router,
	vuetify,
	render: h => h(App)
}).$mount("#app");