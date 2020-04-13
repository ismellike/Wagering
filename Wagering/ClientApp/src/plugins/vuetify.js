import Vue from "vue";
import Vuetify from "vuetify/lib";
import "@mdi/font/css/materialdesignicons.css";

Vue.use(Vuetify);

export default new Vuetify({
	theme: {
		themes: {
			dark: {
				primary: '#673AB7',
				secondary: '#00BCD4',
				accent: '#9C27B0',
				error: '#E34234',
				success: '#14913E',
				info: '#5E8EFF',
				warning: '#FCCC53'
			},
		},
	},
	icons: {
		iconfont: "mdi"
	}
});
