<template>
  <q-page class="index">

    <ProfileCard :profile="profile" v-if="profile"/>

    <div class="timeline">
      <TweetCard v-for="(tweet, i) in tweetContents" :key="i" :tweetContents="tweet" />
    </div>

    <TweetButton />

  </q-page>
</template>

<script lang="ts" setup>
import ProfileCard from 'components/ProfileCard.vue';
import TweetCard from 'components/TweetCard.vue';
import TweetButton from 'components/TweetButton.vue';
import utils from 'src/utils/utils';
import TweetContents from 'src/types/tweet-contents';
import { useProfileStore } from 'src/stores/profile';

const store = useProfileStore();

// ===== プロフィール取得 =====
const profile = await utils.getProfile(store.profileId);

// ===== ツイート取得 =====
const tweetList = await utils.getTweetList(store.profileId);

// ツイート整形
let tweetContents: TweetContents[] = [];

for(let tweet of tweetList) {
  tweetContents.push({
    profileImg: profile.profileImg,
    twitterName: profile.name,
    twitterId: profile.twitterId,
    tweetDate: tweet.createdAt,
    tweetTxt: tweet.text,
  });
}
</script>

<style lang="scss" scoped>
.index {
  width: 60%;
  margin: 0 auto;
  border-left: 1.5px solid $border-color;
  border-right: 1.5px solid $border-color;
  border-bottom: 1.5px solid $border-color;
}

.timeline {
  padding: 15px 0;
}
</style>
