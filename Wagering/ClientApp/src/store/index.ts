import Vue from "vue";
import Vuex from "vuex";
import account from "./modules/account";
import VuexPersist from "vuex-persist";

Vue.use(Vuex);

export interface RootState {
    version: string;
}

const vuexPersist = new VuexPersist({
    key: "Wagering.gg",
    storage: window.localStorage,
});

export default new Vuex.Store<RootState>({
    plugins: [vuexPersist.plugin],
    modules: {
        account,
    },
});
