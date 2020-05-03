import { GetterTree, MutationTree, ActionTree } from "vuex";

class State {
    username: String | null = null;
    id: String | null = null;
    isAuthenticated: Boolean = false;
    token: String | null = null;
}
const getters = <GetterTree<State, any>>{
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
const mutations = <MutationTree<State>>{
    setLogin(state, payload: State) {
        state.username = payload.username;
        state.id = payload.id;
        state.isAuthenticated = payload.isAuthenticated;
        state.token = payload.token;
    },
    setLogout(state) {
        state.username = null;
        state.id = null;
        state.token = null;
        state.isAuthenticated = false;
    },
};
const actions = <ActionTree<State, any>>{
    setLogin({ commit }, payload: State) {
        commit("setLogin", payload);
    },
    setLogout({ commit }) {
        commit("setLogout");
    },
};
export default {
    state: new State(),
    mutations: mutations,
    actions: actions,
    getters: getters,
};
