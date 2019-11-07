import Vue from 'vue'
import Vuex from 'vuex'
import { getBooks, getBook } from './services/BooksService'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    books: [],
    book: null
  },
  mutations: {
    setBooks (state, { books }) {
      state.books = books
    },
    setBook (state, { book }) {
      state.book = book
    }
  },
  actions: {
    async fetchBooks ({ commit }) {
      const response = await getBooks().catch(e => e.response)
      if (response.ok) {
        commit('setBooks', { books: response.data })
      }
    },
    async fetchBook ({ commit }, { id }) {
      const response = await getBook(id).catch(e => e.response)
      if (response.ok) {
        commit('setBook', { book: response.data })
      }
    }
  }
})
