<template lang="pug">
.main-container
  navbar
  .view
    ul.book-list
      li.book-list-item(v-for="book in books" :key="book.id")
        img.book-list-cover(:src='book.image_url' alt='Wolox book cover')
        span.book-list-title.bold.text-small
          | {{book.title}}
        span.book-list-author.grey.text-xsmall
          | {{book.author}}
</template>

<script>
import { mapState, mapActions } from 'vuex'

import Navbar from '@/components/Navbar'
import { setHeaders } from '../config/api'

export default {
  computed: {
    ...mapState([
      'books'
    ]) },
  components: {
    Navbar
  },
  async created () {
    setHeaders()
    this.fetchBooks()
  },
  methods: {
    ...mapActions([
      'fetchBooks'
    ])
  }
}
</script>

<style lang="scss" scoped>
@import '../scss/variables/colors';
@import '../scss/variables/sizes';

.book-list{
  display: flex;
  flex-wrap: wrap;
  padding: 36px 20px;
}

.book-list-item {
  background-color: $white;
  box-shadow: 4px 4px 10px 0 $shadow;
  display: flex;
  flex-direction: column;
  margin: 18px;
  padding: 28px 28px 23px;
  transition: transform 0.3s linear;
  max-width: 200px;
  width: 100%;
  max-height: 380px;

  &:hover {
    transform: scale(1.1, 1.1);
  }
}

.book-list-cover {
  height: 200px;
  max-width: 142px;
}

.book-list-author {
  margin-top: 8px;
}

.book-list-title {
  margin-top: 10px;
}

.view{
  background-color: $wildsand;
  padding:  $navbar-height 150px;
}
</style>
