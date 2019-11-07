import { create } from 'apisauce'
import LocalStorageService from '../services/LocalStorageService'

export const api = create({
  baseURL: process.env.VUE_APP_API_BASE_URL
})

export const setHeaders = () =>
  api.setHeaders({
    'Content-Type': 'application/json',
    'Authorization': LocalStorageService.getAuthToken()
  })

export const clearHeaders = () => api.deleteHeader('Authorization')
