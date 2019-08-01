<template>
  <div>
    <div class="mdl-grid" onload="pageLoaded()">
      <div class="mdl-cell mdl-cell--3-col mdl-cell mdl-cell--1-col-tablet mdl-cell--hide-phone"></div>
      <div class="mdl-cell mdl-cell--6-col mdl-cell--4-col-phone">
        <!--<div v-for="picture in this.pictures" class="image-card" @click="displayDetails(picture.id)">
          <div class="image-card__picture">
            <img :src="picture.url" />
          </div>
          <div class="image-card__comment mdl-card__actions">
            <span>{{ picture.comment }}</span>
          </div>
        </div>-->
        <h4>Thank you for sailing with us</h4>
        <hr />
        <h5>Please rate your experience</h5>
        <div id="textForm">        
          <div id="name">
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
              <input class="mdl-textfield__input" type="text" id="first" pattern="[A-Z,a-z]*" required>
              <label class="mdl-textfield__label" for="sample3">First Name</label>
              <span class="mdl-textfield__error">Only alphabet and no spaces, please</span>
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
              <input class="mdl-textfield__input" type="text" id="last" pattern="[A-Z,a-z]*" required>
              <label class="mdl-textfield__label" for="sample3">Last Name</label>
              <span class="mdl-textfield__error">Only alphabet and no spaces, please</span>
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
              <input class="mdl-textfield__input" type="email" id="email" required>
              <label class="mdl-textfield__label" for="sample3">Email</label>
              <span class="mdl-textfield__error">Invalid email adress</span>
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label getmdl-select">
            <input type="text" value="" class="mdl-textfield__input" id="sample4" readonly>
            <input id="boatType" type="hidden" value="" name="sample4">
            <i class="mdl-icon-toggle__label material-icons">keyboard_arrow_down</i>
              <label for="sample4" class="mdl-textfield__label">Boat Type</label>
              <ul for="sample4" class="mdl-menu mdl-menu--bottom-left mdl-js-menu">
                  <li class="mdl-menu__item" data-val="Samogon, Lagoon 450 Flybridge">Samogon, Lagoon 450 Flybridge</li>
                  <li class="mdl-menu__item" data-val="Madagascar, Lagoon 450">Madagascar, Lagoon 450</li>
                  <li class="mdl-menu__item" data-val="Galapagos, Lagoon 42">Galapagos, Lagoon 42</li>
                  <li class="mdl-menu__item" data-val="Greenland, Lagoon 400">Greenland, Lagoon 400</li>
                  <li class="mdl-menu__item" data-val="Mississippi, Oceanis 50 Family">Mississippi, Oceanis 50 Family</li>
                  <li class="mdl-menu__item" data-val="Ganges, Oceanis 50 Family">Ganges, Oceanis 50 Family</li>
                  <li class="mdl-menu__item" data-val="Orinoco, Beneteau Cyclades 50.5">Orinoco, Beneteau Cyclades 50.5</li>
                  <li class="mdl-menu__item" data-val="Odessa, Sun Odyssey 449">Odessa, Sun Odyssey 449</li>
                  <li class="mdl-menu__item" data-val="Royal, Sun Odyssey 449">Port Royal, Sun Odyssey 449</li>
                  <li class="mdl-menu__item" data-val="Tortuga, Sun Odyssey 449">Tortuga, Sun Odyssey 449</li>
                  <li class="mdl-menu__item" data-val="Himalaya, Beneteau Cyclades 43.4">Himalaya, Beneteau Cyclades 43.4</li>
                  <li class="mdl-menu__item" data-val="Niagara, Beneteau Cyclades 43.4">Niagara, Beneteau Cyclades 43.4</li>
                  <li class="mdl-menu__item" data-val="Tigris, Beneteau Cyclades 43.4">Tigris, Beneteau Cyclades 43.4</li>
                  <li class="mdl-menu__item" data-val="Goa, Beneteau Oceanis 41.1">Goa, Beneteau Oceanis 41.1</li>
                  <li class="mdl-menu__item" data-val="Pharos, Beneteau Cyclades 39.3">Pharos, Beneteau Cyclades 39.3</li>
                  <li class="mdl-menu__item" data-val="Sahara, Beneteau Cyclades 39.3">Sahara, Beneteau Cyclades 39.3</li>
                  <li class="mdl-menu__item" data-val="Patagonia, Beneteau Cyclades 39.3">Patagonia, Beneteau Cyclades 39.3</li>
                  <li class="mdl-menu__item" data-val="Alaska, Beneteau Cyclades 39.3">Alaska, Beneteau Cyclades 39.3</li>
                  <li class="mdl-menu__item" data-val="Siberia, Sun Odyssey 349">Siberia, Sun Odyssey 349</li>
                  <li class="mdl-menu__item" data-val="Panonia, Sun Odyssey 349">Panonia, Sun Odyssey 349</li>
              </ul>
            </div>
            <!--<mdl-select style="margin-top: 1em;" label="Boat Type" id="boatType" v-model="this.placeholderBoat" :options="this.boatType"></mdl-select>-->
            <div id="datePicker">
              <vue-hotel-datepicker
               :startDate="new Date(new Date().getFullYear(),0,1)">
              </vue-hotel-datepicker>
            </div>
          </div>
          <!-- Floating Multiline Textfield -->
          <form action="#">
            <div class="mdl-textfield mdl-js-textfield">
              <textarea class="mdl-textfield__input" type="text" rows= "7" id="sample5" ></textarea>
              <label class="mdl-textfield__label" for="sample5">Write a review...</label>
            </div>
          </form>
        </div>
        <p>(Must select a star value 1-5)</p>
        <div id="full-stars-example-two">
          <div class="rating-group">
            <input disabled checked class="rating__input rating__input--none" name="rating3__1" id="rating3__1-none" value="0" type="radio">
            <label aria-label="1 star" class="rating__label" for="rating3__1-1"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__1" id="rating3__1-1" value="1" type="radio">
            <label aria-label="2 stars" class="rating__label" for="rating3__1-2"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__1" id="rating3__1-2" value="2" type="radio">
            <label aria-label="3 stars" class="rating__label" for="rating3__1-3"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__1" id="rating3__1-3" value="3" type="radio">
            <label aria-label="4 stars" class="rating__label" for="rating3__1-4"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__1" id="rating3__1-4" value="4" type="radio">
            <label aria-label="5 stars" class="rating__label" for="rating3__1-5"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__1" id="rating3__1-5" value="5" type="radio">
          </div>
          <p class="desc" style="font-family: sans-serif; font-size:0.9rem">Boat condition<br/></p>
        </div>
        <div id="full-stars-example-two">
          <div class="rating-group">
            <input disabled checked class="rating__input rating__input--none" name="rating3__2" id="rating3__2-none" value="0" type="radio">
            <label aria-label="1 star" class="rating__label" for="rating3__2-1"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__2" id="rating3__2-1" value="1" type="radio">
            <label aria-label="2 stars" class="rating__label" for="rating3__2-2"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__2" id="rating3__2-2" value="2" type="radio">
            <label aria-label="3 stars" class="rating__label" for="rating3__2-3"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__2" id="rating3__2-3" value="3" type="radio">
            <label aria-label="4 stars" class="rating__label" for="rating3__2-4"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__2" id="rating3__2-4" value="4" type="radio">
            <label aria-label="5 stars" class="rating__label" for="rating3__2-5"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__2" id="rating3__2-5" value="5" type="radio">
          </div>
          <p class="desc" style="font-family: sans-serif; font-size:0.9rem">Check-in/Check-out procedure<br/></p>
        </div>
        <div id="full-stars-example-two">
          <div class="rating-group">
            <input disabled checked class="rating__input rating__input--none" name="rating3__3" id="rating3__3-none" value="0" type="radio">
            <label aria-label="1 star" class="rating__label" for="rating3__3-1"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__3" id="rating3__3-1" value="1" type="radio">
            <label aria-label="2 stars" class="rating__label" for="rating3__3-2"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__3" id="rating3__3-2" value="2" type="radio">
            <label aria-label="3 stars" class="rating__label" for="rating3__3-3"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__3" id="rating3__3-3" value="3" type="radio">
            <label aria-label="4 stars" class="rating__label" for="rating3__3-4"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__3" id="rating3__3-4" value="4" type="radio">
            <label aria-label="5 stars" class="rating__label" for="rating3__3-5"><i class="rating__icon rating__icon--star fa fa-star"></i></label>
            <input class="rating__input" name="rating3__3" id="rating3__3-5" value="5" type="radio">
          </div>
          <p class="desc" style="font-family: sans-serif; font-size:0.9rem">Overall experience<br/></p>
        </div>
        <!-- Accent-colored raised button with ripple -->
        <button id="submitButton" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent">Submit</button>
      </div>
    </div>
    <!--<router-link class="add-picture-button mdl-button mdl-js-button mdl-button--fab mdl-button--colored" to="/post">
      <i class="material-icons">add</i>
    </router-link>!-->
  </div>
</template>

<style scoped>
  /*ratings*/
  /* use display:inline-flex to prevent whitespace issues. alternatively, you can put all the children of .rating-group on a single line */
  /* make hover effect work properly in IE */
  /* hide radio inputs */
  /* hide 'none' input from screenreaders */
  /* set icon padding and size */
  /* set default star color */
  /* if any input is checked, make its following siblings grey */
  /* make all stars orange on rating group hover */
  /* make hovered input's following siblings grey on hover */
#full-stars-example-two .rating-group {
  display: inline-flex;
}
#full-stars-example-two .rating__icon {
  pointer-events: none;
}
#full-stars-example-two .rating__input {
  position: absolute !important;
  left: -9999px !important;
}
#full-stars-example-two .rating__input--none {
  display: none;
}
#full-stars-example-two .rating__label {
  cursor: pointer;
  padding: 0 0.3em;
  font-size: 3rem;
}
#full-stars-example-two .rating__icon--star {
  color: orange;
}
#full-stars-example-two .rating__input:checked ~ .rating__label .rating__icon--star {
  color: #ddd;
}
#full-stars-example-two .rating-group:hover .rating__label .rating__icon--star {
  color: orange;
}
#full-stars-example-two .rating__input:hover ~ .rating__label .rating__icon--star {
  color: #ddd;
}

#textForm, #submitButton {
  margin-bottom: 1.8em;
  margin-top: 2em;
}
#datePicker{
  margin-top:2.8em;
  margin-bottom: 1em;
}
</style>

<script>
export default {}
window.onload = function (){
  
  console.log("window.onload log");

  /******/ 
  /*****Move calendar 2.5em down because of mobile view problems
  /***/
  document.getElementsByClassName("datepicker__input")[0].addEventListener("click",function(e){
    setTimeout(function(){document.getElementsByClassName("datepicker datepicker--open")[0].style.marginTop = "2.5em";
    },500);
  });
   document.getElementsByClassName("datepicker__input")[1].addEventListener("click",function(e){
    setTimeout(function(){document.getElementsByClassName("datepicker datepicker--open")[0].style.marginTop = "2.5em";
    },500);
  });//End move calendar code block



  /******/ 
  /*****Data processing from form upon submission
  /***/
  const submitButton = document.getElementById("submitButton");
  const fName_DOM = document.getElementById("first");
  const lName_DOM = document.getElementById("last");
  const email_DOM = document.getElementById("email");
  const boatType_DOM = document.getElementById("boatType");
  const startDate_DOM = document.querySelectorAll('[tabindex="0"][class="datepicker__input"][data-qa="datepickerInput"]')[0];
  const endDate_DOM = document.querySelectorAll('[tabindex="-1"][class="datepicker__input"][data-qa="datepickerInput"]')[0];
  const textArea_DOM = document.getElementById("sample5");
  var fName, lName, email, boatType, startDate, endDate, textArea, boatCondition, checkInOut, overall, formsValid=false;

  submitButton.addEventListener("click",function(e){

    //save values from DOM elements
    fName = fName_DOM.value;
    lName = lName_DOM.value;
    email = email_DOM.value;
    boatType = boatType_DOM.value;
    startDate = startDate_DOM.innerHTML;
    endDate = endDate_DOM.innerHTML
    textArea = textArea_DOM.value;

    for(var i=1; i<6; i++){//get int value of star ratings
      if(document.getElementById(`rating3__1-${i}`).checked) boatCondition=i;
      if(document.getElementById(`rating3__2-${i}`).checked) checkInOut=i;
      if(document.getElementById(`rating3__3-${i}`).checked) overall=i;
    }

    //log all variables for dev purposes - delete later
    console.log(`
    First Name = ${fName}\n
    Last Name = ${lName}\n
    Email = ${email}\n
    BoatType = ${boatType}\n 
    StartDate = ${startDate}\n
    EndDate = ${endDate}\n
    Text Area = ${textArea}\n
    Boat Condition = ${boatCondition}\n
    CheckInOut = ${checkInOut}\n
    Overall = ${overall}\n
    `)

    //code block for POST request and setting forms and submit button to readonly state
    if(fName_DOM.checkValidity() && lName_DOM.checkValidity() && email_DOM.checkValidity() ){
      submitButton.setAttribute("disabled","");
      fName_DOM.setAttribute("readonly","");
      lName_DOM.setAttribute("readonly","");
      email_DOM.setAttribute("readonly","");
      textArea_DOM.setAttribute("readonly","");

      //add all data to team object
      var data = {}
      data["FirstName"] = fName;
      data["LastName"] = lName;
      data["Email"] = email;
      data["BoatType"] = boatType;
      data["StartDate"] = startDate;
      data["EndDate"] = endDate;
      data["TextArea"] = textArea;
      data["BoatCondition"] = boatCondition;
      data["CheckInOut"] = checkInOut;
      data["Overall"] = overall;

      //initialize xmlhttprequest for POST and GET requests to /api/Reviews url
      var xmlhttp = new XMLHttpRequest();   // new HttpRequest instance
      var theUrl = "http://10.50.2.108:64263/api/Reviews/";
      xmlhttp.overrideMimeType("application/json");//application/json MIME
      //make POST request
      xmlhttp.open("POST", theUrl);
      xmlhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
      xmlhttp.send(JSON.stringify(data));
      console.log(JSON.stringify(data));//send to console log for dev purposes - delete later    
  
    }

  });//End data processing code block
  
}
</script>
