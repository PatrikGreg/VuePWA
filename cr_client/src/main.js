// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import CountryFlag from 'vue-country-flag'
import HotelDatePicker from 'vue-hotel-datepicker'

Vue.component('vue-country-flag', CountryFlag)
Vue.component('vue-hotel-datepicker', HotelDatePicker)
Vue.config.productionTip = false
require('getmdl-select/getmdl-select.min.css')
require('getmdl-select/src/js/getmdl-select.js')
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App, CountryFlag, HotelDatePicker}
  
})
