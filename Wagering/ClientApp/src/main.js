import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import ViewUI from 'view-design';
import '../theme/index.less'

Vue.config.productionTip = false
Vue.use(router)
Vue.use(ViewUI);

new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App)
})