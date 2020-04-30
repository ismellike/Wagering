export default {
	state: {
		isAuthenticated: false,
		username: null,
		token: null,
		id: null
	},
	mutations: {
		setLogin(state, payload) {
			state.username = payload.username;
			state.token = payload.token;
			state.isAuthenticated = true;
			state.id = payload.id;
		},
		setLogout(state) {
			state.username = null;
			state.token = null;
			state.isAuthenticated = false;
			state.id = null;
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
		},
		id: (state) => {
			return state.id;
		}
	},
	actions: {
		setLogin({
			commit
		}, payload) {
			commit('setLogin', payload);
		},
		setLogout({
			commit
		}) {
			commit('setLogout');
		}
	}
}
