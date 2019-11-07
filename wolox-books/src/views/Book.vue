<template lang="pug">
.main-container
  navbar
  .view
    .book
      .book-cover
        img.book-cover-image(:src='book.image_url' alt='Wolox book cover')
      .book-information-container
        .book-title-container
          span.text-xbig.bold
              | {{ book.title }}
          span.text-big.bold.grey.genre
              | {{ book.genre }}
        .book-details-container
          .book-description-container
              span.book-description-title-container.text-medium.bold
                | Book author:
              span.text-medium.grey
                | {{ book.author }}
          .book-description-container
              span.book-description-title-container.text-medium.bold
                | Publisher:
              span.text-medium.grey
                | {{ book.publisher }}
          .book-description-container
              span.book-description-title-container.text-medium.bold
                | Year of publication:
              span.text-medium.grey
                | {{ book.year }}
</template>

<script>
import { mapState, mapActions } from 'vuex'

import { setHeaders } from '../config/api'

import Navbar from '@/components/Navbar'

export default {
  computed: {
    ...mapState([
      'book'
    ]) },
  components: {
    Navbar
  },
  async created () {
    setHeaders()
    const { id } = this.$route.params
    this.fetchBook({ id })
  },
  methods: {
    ...mapActions([
      'fetchBook'
    ])
  }
}
</script>

<style lang="scss" scoped>
@import '../scss/variables/colors';
@import '../scss/variables/sizes';

.book {
  background-color: $white;
  box-shadow: 4px 4px 10px 0 $shadow;
  display: flex;
  height: 416px;
  max-width: 1000px;
  padding: 24px;
  width: 100%;
}

.book-cover {
  margin-right: 52px;
}

.book-cover-image {
  max-width: 250px;
  height: 100%;
}

.book-description-container {
  margin-top: 15px;
}

.book-information-container {
  width: 100%;
}

.book-description-title-container{
  margin-right: 10px;
}

.book-details-container{
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}

.book-title-container {
  display: flex;
  margin-bottom: 35px;
  position: relative;
  width: 100%;

  &::before{
    background-color: $green;
    bottom: -15px;
    content: '';
    height: 4px;
    left: -2px;
    position: absolute;
    width: 100%;
  }
}

.genre{
  margin: 5px 0 0 5px;
}

.view{
  display: flex;
  justify-content: center;
  background-color: $wildsand;
  padding:  150px;
}
</style>
