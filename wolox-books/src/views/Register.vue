<template lang="pug">
.register
  .register-logo-container
    img.register-logo(src='../assets/logo-wolox.png' alt='Wolox logo')
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
      input.main-input(type='mail' v-model='email')
  .input-box
      label.text-xxxsmall.bold.input-label
        | Password
      input.main-input(type='password' v-model='password')
  .sign-up-container
    button.main-button.text-xsmall(@click='signIn')
      | Sign up
  button.secondary-button.text-xsmall.white
    | Login
</template>

<script>
export default {
  data () {
    return {
      firstName: '',
      lastName: '',
      email: '',
      password: ''
    }
  },
  methods: {
    signIn () {
      console.log(
        `
        {
          'user': {
            'email': ${this.email},
            'password': ${this.password},
            'password_confirmation': ${this.password},
            'first_name': ${this.firstName},
            'last_name': ${this.lastName},
            'locale': 'en'
          }
        }
          `
      )
    }
  }
}
</script>

<style lang="scss" scoped>
@import '../scss/variables/colors';
@import '../scss/commons/buttons';
@import '../scss/commons/inputs';

.input-box {
  align-items: flex-start;
  display: flex;
  flex-direction: column;
  margin-top: 16px;
  max-width: 252px;
  width: 110%;
}

.input-label{
  margin-left: 5px;
}

.register {
  align-content: flex-start;
  background-color: $wildsand;
  border-top: 6px solid $cerulean;
  display: flex;
  flex-wrap: wrap;
  height: 525px;
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
  margin-top: 18px;
}

.sign-up-container{
  border-bottom: 2px solid $silver ;
  margin-top: 34px;
  max-width: 252px;
  padding: 15px 0;
  width: 100%;
}
</style>
