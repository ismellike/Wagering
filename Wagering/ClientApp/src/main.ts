import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import axios from "./services/axios";
import "./registerServiceWorker";
import vuetify from "./plugins/vuetify";
import "./services/validation";
import VueTimeago from "vue-timeago";
import "./components/globalComponents";
import Games from "./constants/games";

Vue.use(VueTimeago, {
    name: "Timeago",
    locale: "en",
    locales: {
        "en-US": require("date-fns/locale/en"),
    },
});
Vue.prototype.$axios = axios;
Vue.prototype.$microsoft = { signalr: null };
Vue.prototype.$games = new Games();

new Vue({
    store,
    router,
    vuetify,
    render: (h) => h(App),
}).$mount("#app");
