<template>
  <q-page class="tweet">

    <router-link class="return-link" :to="`/${store.profileId}`">←もどる</router-link>

    <TweetForm class="form" />

  </q-page>
</template>

<script lang="ts" setup>
import TweetForm from 'components/TweetForm.vue';
import { useProfileStore } from 'src/stores/profile';
const store = useProfileStore();
</script>

<style lang="scss" scoped>
.tweet {
  width: 100%;

  .return-link {
    display: inline-block;
    font-size: 1.2rem;
    padding-top: 20px;
  }

  .form {
    margin-top: 100px;
  }
}
</style>
