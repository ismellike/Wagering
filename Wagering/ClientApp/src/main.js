import Vue from 'vue'
import Router from 'vue-router'
import App from './App.vue'
import router from './router'
import store from './store'
import ViewUI from 'view-design';
import '../theme/styles.css'

Vue.config.productionTip = false;
Vue.use(Router);
Vue.use(ViewUI);

new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App)
})