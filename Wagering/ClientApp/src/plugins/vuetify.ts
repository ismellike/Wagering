import Vue from "vue";
import Vuetify from "vuetify/lib";
import "@mdi/font/css/materialdesignicons.css";

Vue.use(Vuetify);

export default new Vuetify({
    theme: {
        dark: true,
        themes: {
            dark: {
                primary: "#B39DDB",
                secondary: "#00ACC1",
                accent: "#673AB7",
                error: "#F4511E",
                success: "#00C853",
                info: "#1565C0",
                warning: "#FFEE58",
            },
        },
    },
    icons: {
        iconfont: "mdi",
    },
});
