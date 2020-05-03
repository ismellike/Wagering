import Vue from "vue";
import Vuex from "vuex";
import account from "./modules/account";
import VuexPersist from "vuex-persist";

Vue.use(Vuex);

const vuexPersist = new VuexPersist({
    key: "Wagering.gg",
    storage: window.localStorage,
});

export default new Vuex.Store({
    plugins: [vuexPersist.plugin],
    modules: {
        account,
    },
});
