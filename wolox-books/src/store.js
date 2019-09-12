import Vue from 'vue'
import Vuex from 'vuex'
import { getBooks } from './services/BooksService'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    books: []
  },
  mutations: {
    setBooks (state, { books }) {
      state.books = books
    }
  },
  actions: {
    async fetchBooks ({ commit }) {
      const response = await getBooks().catch(e => e.response)
      if (response.ok) {
        commit('setBooks', { books: response.data })
      }
    }
  }
})
