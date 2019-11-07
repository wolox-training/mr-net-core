import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export const routes = {
  register: 'register',
  login: 'login',
  booklist: 'booklist'
}

export default new Router({
  routes: [
    {
      path: '/register',
      name: routes.register,
      component: () => import(/* webpackChunkName: "register" */ './views/Register.vue')
    },
    {
      path: '/login',
      name: routes.login,
      component: () => import(/* webpackChunkName: "login" */ './views/Login.vue')
    },
    {
      path: '/booklist',
      name: routes.booklist,
      component: () => import(/* webpackChunkName: "booklist" */ './views/BookList.vue')
    },
    {
      path: '/',
      redirect: { name: routes.login }
    }
  ]
})
