import { GetterTree, MutationTree, ActionTree } from "vuex";
import AuthService from "@/services/authentication";

class State {
    username: string | null = null;
    id: string | null = null;
    isAuthenticated = false;
    token: string | null = null;
}
const getters: GetterTree<State, any> = {
    isAuthenticated: (state) => {
        return state.isAuthenticated;
    },
    username: (state) => {
        return state.username;
    },
    token: (state) => {
        return state.token;
    },
    id: (state) => {
        return state.id;
    },
};
const mutations: MutationTree<State> = {
    setLogin(state, payload: State) {
        state.username = payload.username;
        state.id = payload.id;
        state.isAuthenticated = true;
        state.token = payload.token;
    },
    setLogout(state) {
        state.username = null;
        state.id = null;
        state.token = null;
        state.isAuthenticated = false;
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
        const user = await AuthService.getUser();
        if (user) {
            const token = await AuthService.getAccessToken();
            const payload = {
                username: user.name,
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
