<template>
  <section class="profile-card">

    <div class="bg-img" v-if="profile.profileBgImg">
      <img :src="profile.profileBgImg" alt="背景画像" />
    </div>

    <div class="profile-img-wrapper" v-if="profile.profileImg">
      <img class="profile-img" :src="profile.profileImg" alt="プロフィール画像"/>
    </div>

    <div class="txt-area">
      <h1 class="name" v-if="profile.name">{{ profile.name }}</h1>
      <p class="id" v-if="profile.twitterId">{{ profile.twitterId }}</p>

      <p class="txt" v-if="profile.profileText" v-html="profile.profileText">
      </p>

      <p class="follow-count">
        <span>{{ utils.formatNumToKanji(profile.followCount) }}</span>フォロー中　<span>{{ utils.formatNumToKanji(profile.followerCount) }}</span>フォロワー
      </p>
    </div>

  </section>
</template>

<script lang="ts" setup>
import utils from 'src/utils/utils';
import { PropType } from 'vue';
import Profile from 'src/types/profile';

defineProps({
  profile: {
    type: Object as PropType<Profile>,
    required: true,
  },
});
</script>

<style lang="scss" scoped>
.profile-card {
  .bg-img {
    width: 100%;
    height: 200px;
    overflow: hidden;
  }

  .profile-img-wrapper {
    position: relative;
  }

  .profile-img {
    width: 100px;
    height: 100px;
    object-fit: cover;
    position: absolute;
    top: -50px;
    left: 20px;
    border-radius: 50%;
    border: 5px solid #000;
  }

  .txt-area {
    padding: 70px 0 0 15px;
  }

  .name {
    font-size: 1.5rem;
    font-weight: 600;
    letter-spacing: 2px;
    line-height: 1;
  }

  .id {
    color: $caption-color;
  }

  .txt {
    padding: 15px 0;
  }

  .follow-count {
    color: $caption-color;
  }

  .follow-count span {
    color: #fff;
    padding-right: 5px;
  }
}
</style>
