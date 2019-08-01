// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import CountryFlag from 'vue-country-flag'
import HotelDatePicker from 'vue-hotel-datepicker'
//import MdlSelect from 'vue-mdl'

Vue.component('vue-country-flag', CountryFlag)
Vue.component('vue-hotel-datepicker', HotelDatePicker)
//Vue.component('mdl-select', require('vue-mdl/src/select.vue').default)
//require('vue-mdl/src/vue-mdl.js')

Vue.config.productionTip = false
require('getmdl-select/getmdl-select.min.css')
require('getmdl-select/getmdl-select.min.js')
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App, CountryFlag, HotelDatePicker}
  
})



/******/
/*****Populated #dropdownList with data from mongodb database
/***/
/*
//initialize xmlhttprequest for POST and GET requests to /api/teams url
var xmlhttp = new XMLHttpRequest();   // new HttpRequest instance
var theUrl = "http://10.50.2.108:64263/api/Boats/";
var dropdownData;
//make GET request
xmlhttp.overrideMimeType("application/json");
xmlhttp.open('GET', theUrl, true);
xmlhttp.onload = function () {
    var jsonGETResponse = JSON.parse(xmlhttp.responseText);
    console.log(jsonGETResponse);
    dropdownData = JSON.parse(JSON.stringify(jsonGETResponse));
}
xmlhttp.send();*/