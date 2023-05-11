<template>
  <q-layout view="hHh lpr fff">
    <DefaultHeader />

    <Suspense>
      <template #default>
        <q-page-container>
          <router-view />
        </q-page-container>
      </template>
    </Suspense>


    <DefaultFooter />
  </q-layout>
</template>

<script lang="ts" setup>
import DefaultHeader from 'components/layouts/DefaultHeader.vue';
import DefaultFooter from 'components/layouts/DefaultFooter.vue';
import { useRouter } from 'vue-router';
import { useProfileStore } from 'src/stores/profile';

// boot/redirect.tsの方でrouterのparamが取れないため、もうここでstoreの初期化する、、
const store = useProfileStore();

const route = useRouter().currentRoute.value;
const id = route.params.id;

if(id && !isNaN(Number(id))) {
  store.setProfileId(Number(id));
}
</script>
