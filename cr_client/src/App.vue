<template>
  <div class="mdl-layout mdl-js-layout mdl-layout--fixed-header">
    <header class="mdl-layout__header" style="background-color: #00CA9D;">
      <div class="mdl-layout__header-row">
        <span class="mdl-layout-title">Checkout Review</span>
      </div>
    </header>
    <div class="mdl-layout__drawer">
      <span class="mdl-layout-title">Choose a language:</span>
      <nav class="mdl-navigation">
        <router-link class="mdl-navigation__link" to="/" @click.native="hideMenu"><!--<vue-country-flag country='gb' size='normal'/>-->&nbsp;English</router-link>
        <router-link class="mdl-navigation__link" to="/" @click.native="hideMenu"><!--<vue-country-flag country='de' size='normal'/>-->&nbsp;Deutsch</router-link>
        <router-link class="mdl-navigation__link" to="/" @click.native="hideMenu"><!--<vue-country-flag country='ru' size='normal'/>-->&nbsp;Русский</router-link>
        <router-link class="mdl-navigation__link" to="/" @click.native="hideMenu"><!--<vue-country-flag country='fr' size='normal'/>-->&nbsp;Français</router-link>
        <router-link class="mdl-navigation__link" to="/" @click.native="hideMenu"><!--<vue-country-flag country='it' size='normal'/>-->&nbsp;Italiano</router-link>
        <router-link class="mdl-navigation__link" to="/" @click.native="hideMenu"><!--<vue-country-flag country='es' size='normal'/>-->&nbsp;Español</router-link>
      </nav>
    </div>
    <main class="mdl-layout__content">
      <div class="page-content">
        <router-view></router-view>
      </div>
    </main>
  </div>
</template>


<script>
require('material-design-lite')
export default {
  name: 'app',
  methods: {
    hideMenu: function () {
      document.getElementsByClassName('mdl-layout__drawer')[0].classList.remove('is-visible')
      document.getElementsByClassName('mdl-layout__obfuscator')[0].classList.remove('is-visible')
    }
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/icon?family=Material+Icons');
@import url('https://code.getmdl.io/1.2.1/material.blue-red.min.css');

body {
  margin: 0;
}

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

main {
  text-align: center;
  margin-top: 40px;
}

header {
  margin: 0;
  height: 56px;
  padding: 0 16px 0 24px;
  background-color: #35495E;
  color: #ffffff;
}

header span {
  display: block;
  position: relative;
  font-size: 20px;
  line-height: 1;
  letter-spacing: .02em;
  font-weight: 400;
  box-sizing: border-box;
  padding-top: 16px;
}

/*margin-bottom override for title*/
.mdl-layout-title{
  margin-bottom:0.5em;
}
/*Error colors override*/
.mdl-textfield.is-invalid .mdl-textfield__input{
  border-color: #FF5252;
}
.mdl-textfield.is-invalid .mdl-textfield__label:after {
  background-color: #FF5252!important;
}
.mdl-textfield__error, .mdl-textfield--floating-label.is-invalid .mdl-textfield__label  {
  color: #FF5252;
}
</style>
