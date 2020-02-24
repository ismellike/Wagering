import Vue from "vue";
import Vuex from "vuex";
import account from "./modules/account";
import VuexPersist from "vuex-persist";
import { ApplicationName } from "@/auth/AuthConstants";

Vue.use(Vuex);

const vuexPersist = new VuexPersist({
  key: ApplicationName,
  storage: window.localStorage
});

export default new Vuex.Store({
  plugins: [vuexPersist.plugin],
  modules: {
    account
  }
});
