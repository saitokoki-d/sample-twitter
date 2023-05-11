import { RouteRecordRaw } from 'vue-router';

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: ':id?', component: () => import('pages/IndexPage.vue') },
    ],
  },

  {
    path: '/tweet',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: ':id?', component: () => import('pages/TweetPage.vue') },
    ],
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue'),
  },
];

export default routes;
