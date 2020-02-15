const state = {
    isAuthenticated: false,
    username: undefined
}
const mutations = {
    setLogin(state, payload) {
        state.username = payload
        state.isAuthenticated = true
    },
    setLogout(state) {
        state.username = undefined
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