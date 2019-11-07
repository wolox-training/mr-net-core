import Vue from 'vue'
import VueI18n from 'vue-i18n'
import Vuelidate from 'vuelidate'
import App from './App.vue'
import router from './router'
import store from './store'

import { messages } from './config/i18n'

Vue.config.productionTip = false
Vue.use(Vuelidate)
Vue.use(VueI18n)

export const i18n = new VueI18n({
  locale: 'es',
  messages
})

new Vue({
  i18n,
  router,
  store,
  render: h => h(App)
}).$mount('#app')
