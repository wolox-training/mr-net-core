<template lang="pug">
.navbar
  .logo
    img.navbar-image(src='../assets/logo-wolox.png' alt='Wolox logo')
    span.bold.text-xxxsmall
      | B O O K S
  button.button-logout.text-small(type='button' @click='logout')
    | Logout
</template>

<script>
import LocalStorageService from '../services/LocalStorageService'
import { routes } from '../router'

export default {
  methods: {
    logout () {
      LocalStorageService.removeAuthToken()
      this.$router.push({ name: routes.login })
    }
  }
}
</script>

<style lang="scss" scoped>
@import '../scss/variables/sizes';
@import '../scss/variables/colors';
@import '../scss/commons/buttons';

.button-logout {
  background-color: $white;
  border: none;
}

.logo {
  align-self: center;
  display: flex;
  flex-direction: column;
}

.navbar {
  align-items: center;
  border-top: 6px solid $cerulean;
  box-shadow: 0 4px 10px 0 $shadow;
  display: flex;
  height: $navbar-height;
  justify-content: space-around;
  position: fixed;
  width: 100%;
}

.navbar-image {
  height: $navbar-image-height;
}
</style>
