export default {
	state: {
		isAuthenticated: false,
		username: null,
		token: null
	},
	mutations: {
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
	},
	getters: {
		isAuthenticated: (state) => {
			return state.isAuthenticated;
		},
		username: (state) => {
			return state.username;
		},
		token: (state) => {
			return state.token;
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
