import Vue from 'vue'
import Router from 'vue-router'
import App from './App.vue'
import router from './router'
import store from './store'
import '../theme/styles.css'
import axios from 'axios'

Vue.config.productionTip = false;
Vue.use(Router);
Vue.prototype.$axios = axios;

new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App)
})