import { defineStore } from 'pinia';
import constants from 'src/utils/constants';

export const useProfileStore = defineStore('profile', {
  state: () => ({
    profileId: constants.TWITTER_MIWA_ID
  }),

  getters: {
  },

  actions: {
    setProfileId (id: number) {
      this.profileId = id;
    }
  }
});
