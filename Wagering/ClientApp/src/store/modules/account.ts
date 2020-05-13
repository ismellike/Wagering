import { GetterTree, MutationTree, ActionTree } from "vuex";
import AuthService from "@/services/authentication";

class State {
    displayName: string | null = null;
    id: string | null = null;
    isAuthenticated = false;
    isInitialized = false;
    token: string | null = null;
}
const getters: GetterTree<State, any> = {
    isAuthenticated: (state) => {
        return state.isAuthenticated;
    },
    isInitialized: (state) => {
        return state.isInitialized;
    },
    displayName: (state) => {
        return state.displayName;
    },
    token: (state) => {
        return state.token;
    },
    id: (state) => {
        return state.id;
    },
    shouldGuard: (state) => {
        return state.isInitialized && !state.isAuthenticated;
    },
};
const mutations: MutationTree<State> = {
    setLogin(state, payload: State) {
        state.displayName = payload.displayName;
        state.id = payload.id;
        state.isAuthenticated = true;
        state.token = payload.token;
    },
    setLogout(state) {
        state.displayName = null;
        state.id = null;
        state.token = null;
        state.isAuthenticated = false;
    },
    setInitialized(state) {
        state.isInitialized = true;
    },
};
const actions: ActionTree<State, any> = {
    setLogin({ commit }, payload: State) {
        commit("setLogin", payload);
    },
    setLogout({ commit }) {
        commit("setLogout");
    },
    async init({ commit }) {
        commit("setInitialized");
        const user = await AuthService.getUser();
        if (user) {
            const token = await AuthService.getAccessToken();
            const payload = {
                displayName: user.display_name,
                id: user.sub,
                isAuthenticated: true,
                token: token,
            } as State;
            commit("setLogin", payload);
            return true;
        }
        return false;
    },
};
export default {
    state: new State(),
    mutations: mutations,
    actions: actions,
    getters: getters,
};
