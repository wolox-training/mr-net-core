import { api } from '../config/api'

export const register = userDetails => api.post('/users', userDetails)
