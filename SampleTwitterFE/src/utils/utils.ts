import constants from 'src/utils/constants';
import Profile from 'src/types/profile';
import ProfileObj from 'src/types/profile-obj';
import Tweet from 'src/types/tweet';
import TweetObj from 'src/types/tweet-obj';

export default class Utils {
  /**
   * 数値⇒漢字桁付き数値の変換（適当）
   * @param {number} num 対象数値
   * @returns {string} 漢字変換後数値
   */
  static formatNumToKanji (num: number | undefined) {
    if(typeof num !== 'number') return undefined;

    if(10000 <= num) {
      return `${num / 10000}万`;
    }

    return `${num}`;
  }

  /**
   * 日時変換
   * @param {string} datetime 対象日付
   * @returns {string} yyyy年MM月dd日 hh時mm分ss秒
   */
  static formatDateTime (datetime: string | undefined) {
    if(typeof datetime !== 'string') return '';

    const date = new Date(datetime);

    return `${date.getFullYear()}年${date.getMonth() + 1}月${date.getDate()}日 ${date.getHours()}:${date.getMinutes()}:${date.getSeconds()}`;
  }

  /**
   * プロフィール取得
   * @param {string | number} id プロフィールID
   * @returns {Promise<Profile>} プロフィールオブジェクト
   */
  static async getProfile (id: string | number | undefined): Promise<Profile> {
    if(typeof id === undefined) return new ProfileObj();

    let profile: Profile = new ProfileObj();

    try {
      profile = await fetch(`${constants.API_PROFILES}/${id}`)
                .then((res) => res.json())
                .then((prof) => { return prof });
    } catch (e) {
      console.error('プロフィール取得失敗だよ');
      console.error(e);
    }

    return profile;
  }

  /**
   * ツイート取得
   * @param {string | number} profileId プロフィールID
   * @returns {Promise<Tweet>} ツイート配列
   */
  static async getTweetList (profileId: string | number | undefined): Promise<Tweet[]> {
    if(typeof profileId === undefined) return [];

    let tweetList: Tweet[] = [];

    try {
      tweetList = await fetch(`${constants.API_TWEETS}/${profileId}`)
                  .then((res) => res.json())
                  .then((tweets) => { return tweets });
    } catch (e) {
      console.error('ツイート取得失敗だよ');
      console.error(e);
    }

    tweetList.sort((a, b) => Date.parse(b.createdAt) - Date.parse(a.createdAt));

    return tweetList;
  }

  /**
   * ツイート登録
   */
  static async addTweet (profileId: number, tweetText: string) {
    const tweetData = new TweetObj();

    tweetData.profileId = profileId;
    tweetData.text = tweetText;

    try {
      await fetch(`${constants.API_TWEETS}`, {
        method: 'post',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(tweetData),
      });
    } catch (e) {
      console.error('ツイート登録失敗だよ。出直しな。');
      console.error(e);
    }
  }
}
