import Vue from "vue";
import Vuex from "vuex";
import account from "./modules/account";

Vue.use(Vuex);

export interface RootState {
    version: string;
}

export default new Vuex.Store<RootState>({
    modules: {
        account,
    },
});
