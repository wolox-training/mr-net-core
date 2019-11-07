import { helpers } from 'vuelidate/lib/validators'

const password = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/

export const passwordRegex = helpers.regex('passwordRegex', password)
