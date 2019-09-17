import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export const routes = {
  register: 'register',
  login: 'login',
  booklist: 'booklist',
  book: 'book'
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
      component: () => import(/* webpackChunkName: "feed" */ './views/BookList.vue')
    },
    {
      path: '/book/:id',
      name: routes.book,
      component: () => import(/* webpackChunkName: "book" */ './views/Book.vue')
    },
    {
      path: '/',
      redirect: { name: routes.login }
    }
  ]
})
