import Tweet from 'src/types/tweet';

export default class TweetObj implements Tweet {
  id = 0;                    // DBでauto_increment
  profileId = 0;
  text = '';
  createdAt = '0001-01-01';  // DBで自動挿入
}
