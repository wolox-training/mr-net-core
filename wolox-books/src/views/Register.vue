<template lang="pug">

.register
  .register-logo-container
    img.register-logo(src="../assets/logo-wolox.png" alt="Wolox logo")
    span.text-xxxsmall.bold
      | B O O K S
  .input-box
    label.text-xxxsmall.bold.input-label
      | First Name
    input.main-input(v-model='firstName')
  .input-box
    label.text-xxxsmall.bold.input-label
      | Last Name
    input.main-input(v-model='lastName')
  .input-box
    label.text-xxxsmall.bold.input-label
      | Email
    input.main-input(type='email' v-model='email')
    span.text-xxxsmall.error(v-show='invalidEmail')
      | Email is invalid
    span.text-xxxsmall.error(v-show='missingEmail')
      | Email is required
  .input-box
    label.text-xxxsmall.bold.input-label
      | Password
    input.main-input(type='password' v-model='password')
    span.text-xxxsmall.error(v-show='invalidPassword')
      | Password is invalid
    span.text-xxxsmall.error(v-show='missingPassword')
      | Password is required
  .sign-up-container
      button.main-button.text-xsmall(@click='submit' type='button')
      | Sign up
   router-link.secondary-button.text-xsmall.white(:to='router.login')
    | Login
</template>

<script>
import { required, helpers, minLength, email } from 'vuelidate/lib/validators'

import { Register } from '../services/AuthService'

const passwordRegex = helpers.regex('passwordRegex', /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/)

export default {
  data () {
    return {
      firstName: '',
      lastName: '',
      email: '',
      password: '',
      showErrors: false
    }
  },
  validations: {
    email: {
      required,
      email
    },
    password: {
      required,
      minLength: minLength(6),
      passwordRegex
    }
  },
  computed: {
    invalidEmail () {
      return this.showErrors && !this.$v.email.email
    },
    invalidPassword () {
      return this.showErrors && !this.$v.password.passwordRegex
    },
    missingEmail () {
      return this.showErrors && !this.$v.email.required
    },
    missingPassword () {
      return this.showErrors && !this.$v.password.required
    }
  },
  methods: {
    submit () {
      if (this.$v.$invalid) {
        this.showErrors = true
      } else {
        Register({
          user: {
            email: this.email,
            password: this.password,
            password_confirmation: this.password,
            first_name: this.firstName,
            last_name: this.lastName,
            locale: 'en'
          }
        })
      }
    }
  }
}
</script>

<style lang="scss" scoped>
@import '../scss/variables/colors';
@import '../scss/commons/buttons';
@import '../scss/commons/inputs';

.error {
  color: red;
  margin-top: 5px;
}

.input-box {
  align-items: flex-start;
  display: flex;
  flex-direction: column;
  margin-top: 16px;
  max-width: 252px;
  width: 110%;
}

.input-label {
  margin-left: 5px;
}

.register {
  align-content: flex-start;
  background-color: $wildsand;
  border-top: 6px solid $cerulean;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  padding-bottom: 24px;
  width: 300px;
}

.register-form {
  width: 100%;
}

.register-logo {
  height: 70px;
}

.register-logo-container {
  display: flex;
  flex-direction: column;
}

.secondary-button {
  align-items: center;
  display: flex;
  margin-top: 18px;
  text-decoration: none;
}

.sign-up-container {
  border-bottom: 2px solid $silver;
  margin-top: 34px;
  max-width: 252px;
  padding: 15px 0;
  width: 100%;
}
</style>
