<template lang="pug">
.main-container
  navbar
  .view
    .book
      .book-cover
          img.book-cover-image(src='assets/logo-wolox.png' alt='Wolox book cover')
      span.text-xbig.bold.book-title
          | Título del libro
      span.text-big.bold.grey.book-genre
          | (género del libro)
      .book-details-box
          .book-description-box
              span.text-medium.bold
                | Book author:
              span.text-medium.grey
                | Nombre del autor del libro
          .book-description-box
              span.text-medium.bold
                | Publisher:
              span.text-medium.grey
                | Nombre de la editorial
          .book-description-box
              span.text-medium.bold
                | Year of publication:
              span.text-medium.grey
                | Año de publicación
</template>

<script>
import Navbar from '@/components/Navbar'

export default {
  components: {
    Navbar
  }
}
</script>

<style lang="scss" scoped>
@import '../scss/variables/colors';
@import '../scss/variables/sizes';
@import '../scss/commons/buttons';
@import '../scss/commons/inputs';

.book {
  background-color: $white;
  box-shadow: 4px 4px 10px 0 $shadow;
  display: flex;
  height: 416px;
  margin: 108px 0 0 80px;
  max-width: 1000px;
  padding: 24px;
  width: 100%;
}

.book-cover {
  grid-column: 1;
  grid-row: 1;
  position: relative;
}

.book-description-box {
  margin-bottom: 36px;
}

.view{
  background-color: $wildsand;
  padding:  $navbar-height 150px;
}

.book-details-box {
  grid-column: 2 / span 3;
  grid-row: 2;
  margin-left: 52px;
}

.book-genre {
  grid-column: 3;
  grid-row: 1;
  padding-top: 6px;
}

.book-title {
  grid-column: 2 / span 3;
  grid-row: 1;
  margin-left: 52px;
  position: relative;

  &::before {
    background-color: $green;
    bottom: 55px;
    content: '';
    height: 4px;
    left: -2px;
    position: absolute;
    width: 100%;
  }
}

@media only screen and (max-width: $desktop-min-width) {
  .back-button {
    margin-bottom: 33px;
  }

  .book {
    height: 570px;
    margin-top: 33px;
    margin: 0;
    max-width: 854px;
    padding: 32px;
  }

  .book-cover {
    grid-column: 1;
    grid-row: 2;
  }

  .book-details-box {
    align-self: center;
  }

  .book-title {
    align-items: center;
    display: flex;
    flex-direction: column;
    grid-column: 2;
    justify-self: center;
    margin: 0;

    &::before {
      display: none;
    }
  }
}
</style>
