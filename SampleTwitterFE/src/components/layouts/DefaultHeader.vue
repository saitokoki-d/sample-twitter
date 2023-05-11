<template>
  <q-header class="header">
    <nav class="nav">
      <img src="https://api.iconify.design/typcn/social-twitter.svg?color=white" alt="icon"
           class="icon"/>
      <p class="title">Twitterもどき</p>
    </nav>
  </q-header>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'DefaultHeader',
});
</script>

<style lang="scss" scoped>
@import 'src/css/header.scss';
</style>
