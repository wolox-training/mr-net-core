import { api } from '../config/api'

export const Register = userDetails => api.post('/users', userDetails)

export const Login = credentials => api.post('users/sessions', credentials)
