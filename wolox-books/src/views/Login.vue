<template lang="pug">
.login
  form
    .login-logo-container
      img.login-logo(src='../assets/logo-wolox.png' alt='Wolox logo')
      span.text-xxxsmall.bold
        | B O O K S
    .input-box
      label.text-xxxsmall.bold.input-label
        | Email
      input.main-input(type='mail' v-model='email')
      span.error.text-xxxsmall(v-show='invalidEmail')
        | Email is invalid
      span.error.text-xxxsmall(v-show='missingEmail')
        | Email is required
    .input-box
      label.text-xxxsmall.bold.input-label
        | Password
      input.main-input(type='password' v-model='password')
      span.error.text-xxxsmall(v-show='missingPassword')
        | Password is required
    .sign-up-container
      button.main-button.text-xsmall(@click='submit')
        | Login
    router-link.secondary-button.text-xsmall.white(:to='{ name: routes.register }')
      | Sign Up
</template>

<script>
import { required, minLength, email } from 'vuelidate/lib/validators'

import LocalStorageService from '../services/LocalStorageService'
import { login } from '../services/AuthService'
import { routes } from '../router'

import { passwordRegex } from '@/utils/regex'

export default {
  data () {
    return {
      firstName: '',
      lastName: '',
      email: '',
      password: '',
      showErrors: false,
      routes
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
    missingEmail () {
      return this.showErrors && !this.$v.email.required
    },
    missingPassword () {
      return this.showErrors && !this.$v.password.required
    }
  },
  methods: {
    async submit () {
      if (this.$v.$invalid) {
        this.showErrors = true
      } else {
        const response = await login({ session: {
          email: this.email,
          password: this.password
        }
        }).catch(e => e.response)
        if (response.ok) {
          LocalStorageService.setAuthToken(response.data.access_token)
          this.$router.push('/feed')
        }
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

.login {
  align-content: flex-start;
  background-color: $wildsand;
  border-top: 6px solid $cerulean;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  padding-bottom: 24px;
  width: 300px;
}

.login-form {
  width: 100%;
}

.login-logo {
  height: 70px;
}

.login-logo-container {
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
