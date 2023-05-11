<template>
  <div class="tweet-form">

    <img class="profile-img" :src="`${profile.profileImg}`" alt="プロフィール画像" v-if="profile.profileImg"/>

    <q-form @submit="onSubmit">
      <q-input v-model="tweetText" type="textarea" label="いまどうしてる？" filled dark />

      <div class="submit-btn">
        <q-btn label="ツイートする" type="submit" color="tweet-btn" rounded/>
      </div>
    </q-form>

  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import utils from 'src/utils/utils';
import Profile from 'src/types/profile';
import { useProfileStore } from 'src/stores/profile';
import { storeToRefs } from 'pinia';

const router = useRouter();

let tweetText = ref('');
const { profileId } = storeToRefs(useProfileStore());

// ===== プロフィール取得 =====
const profile: Profile = await utils.getProfile(profileId.value);

/**
 * ツイート登録
 */
async function onSubmit() {

  await utils.addTweet(profileId.value, tweetText.value);

  router.push({ path: `/${profileId.value}` })

}
</script>

<style lang="scss" scoped>
.tweet-form {
  max-width: 600px;
  margin: 0 auto;
  padding: 16px;
  border: 1.5px solid $border-color;
  border-radius: 16px;

  .profile-img {
    width: 50px;
    height: 50px;
    object-fit: cover;
    border-radius: 50%;
  }

  .submit-btn {
    display: flex;
    justify-content: right;
    width: 100%;
    padding-top: 20px;
  }

  // q-btnのcolorに追加
  .text-tweet-btn {
    color: #fff !important;
  }
  .bg-tweet-btn {
    background: $main-color !important;
  }
}
</style>
