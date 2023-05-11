export default interface Profile {
  id: number;
  twitterId: string | undefined;
  name: string | undefined;
  profileImg: string | undefined;
  profileBgImg: string | undefined;
  profileText: string | undefined;
  followCount: number | undefined;
  followerCount: number | undefined;
  createdAt: string;
}
