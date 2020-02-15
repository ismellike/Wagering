import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
    name: "store",
    modules: {
        account: {
            state: {
                isAuthenticated: false,
                username: undefined
            },
            mutations: {
                setLogin(state, payload) {
                    state.username = payload
                    state.isAuthenticated = true
                },
                setLogout(state) {
                    state.username = undefined
                    state.isAuthenticated = false
                }
            },
            actions: {
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
        }
    }
})