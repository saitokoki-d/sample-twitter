<template>
  <div class="tweet-card">

    <img class="profile-img" :src="tweetContents.profileImg" alt="プロフィール画像" v-if="tweetContents.profileImg"/>

    <div class="right-area">

      <div class="info">
        <p class="name" v-if="tweetContents.twitterName">{{ tweetContents.twitterName }}</p>
        <p class="id" v-if="tweetContents.twitterId">{{ tweetContents.twitterId }}</p>
        <p class="date" v-if="tweetContents.tweetDate">・{{ utils.formatDateTime(tweetContents.tweetDate) }}</p>
      </div>

      <p class="content-txt" v-html="tweetContents.tweetTxt" v-if="tweetContents.tweetTxt"></p>

    </div>

  </div>
</template>

<script lang="ts" setup>
import utils from 'src/utils/utils';
import { PropType } from 'vue';
import TweetContents from 'src/types/tweet-contents';

defineProps({
  tweetContents: {
    type: Object as PropType<TweetContents>,
    required: true,
  },
});
</script>

<style lang="scss" scoped>
.tweet-card {
  display: flex;
  padding: 15px;
  border-top: 1.5px solid $border-color;

  .profile-img {
    width: 50px;
    height: 50px;
    object-fit: cover;
    border-radius: 50%;
  }

  .right-area {
    padding-left: 15px;
  }

  .info {
    display: flex;
    .name {
      font-weight: bold;
    }

    .id {
      padding-left: 10px;
      color: $caption-color;
    }

    .date {
      color: $caption-color;
    }
  }
}
</style>
