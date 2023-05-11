import Profile from 'src/types/profile';

export default class ProfileObj implements Profile {
  id = 0;
  twitterId = '';
  name = '';
  profileImg = '';
  profileBgImg = '';
  profileText = '';
  followCount = 0;
  followerCount = 0;
  createdAt = '0001-01-01';
}
