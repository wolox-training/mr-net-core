import { api } from '../config/api'

export const getBooks = () => api.get(`/books`)
export const getBook = (id) => api.get(`/books/${id}`)
