const apiHost = process.env.NODE_ENV === 'development' ? 'https://localhost:7011' : '';

const Constantes = {
  API_HOST: apiHost,
  API_PROFILES: `${apiHost}/api/Profiles`,
  API_TWEETS: `${apiHost}/api/Tweets`,
  TWITTER_MIWA_ID: 1,
};

export default Constantes;
