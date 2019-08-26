import { api } from '../config/api'

export const Register = userDetails => api.post('/users', userDetails)
