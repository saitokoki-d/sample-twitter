import { boot } from 'quasar/wrappers'
import constants from 'src/utils/constants';

// more info on params: https://v2.quasar.dev/quasar-cli/boot-files
export default boot(({ urlPath, redirect }) => {

  // IDが指定されていなかったら美輪さんに遷移
  if(urlPath === '/') {
    redirect({ path: `/${constants.TWITTER_MIWA_ID}` });
  }

})
