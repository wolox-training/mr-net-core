import { api } from '../config/api'

export const login = credentials => api.post('users/sessions', credentials)
export const register = userDetails => api.post('/users', userDetails)
