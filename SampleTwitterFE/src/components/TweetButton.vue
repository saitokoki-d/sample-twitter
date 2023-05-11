<template>
  <div class="tweet-btn">

    <q-btn color="tweet-btn" icon="add" size="1.5rem" round :href="`/tweet/${store.profileId}`" />

  </div>
</template>

<script lang="ts" setup>
import { useProfileStore } from 'src/stores/profile';
const store = useProfileStore();
</script>

<style lang="scss" scoped>
.tweet-btn {
  @import "src/css/mixin.scss";

  position: fixed;
  bottom: 50px;
  right: 20%;

  // q-btnのcolorに追加
  .text-tweet-btn {
    color: #fff !important;
  }
  .bg-tweet-btn {
    background: $main-color !important;
  }
}
</style>
