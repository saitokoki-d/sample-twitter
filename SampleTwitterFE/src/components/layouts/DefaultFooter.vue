<template>
  <q-footer class="footer">
    <div class="content">
      &copy; 2023 - SampleTwitter - <a asp-area="" asp-page="/Privacy">Privacy</a>
    </div>
  </q-footer>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'DefaultFooter',
});
</script>

<style lang="scss" scoped>
@import 'src/css/footer.scss';
</style>
