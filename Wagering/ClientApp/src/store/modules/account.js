const state = {
    isAuthenticated: false,
    username: null,
    token: null
}
const mutations = {
    setLogin(state, payload) {
        state.username = payload.username
        state.token = payload.token
        state.isAuthenticated = true
    },
    setLogout(state) {
        state.username = null
        state.token = null
        state.isAuthenticated = false
    }
}
const actions = {
    setLogin({
        commit
    }, payload) {
        commit('setLogin', payload)
    },
    setLogout({
        commit
    }) {
        commit('setLogout')
    }
}
export default {
    state,
    mutations,
    actions
}