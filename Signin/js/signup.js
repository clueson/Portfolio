/* Js and Jquery code design by Colin Coulson 01/03/19 */

/* A Test example sign in form */

/* TODO's 
1.  Change to MVC pattern for seperation of concerns
2.  Create properties for all the Jquery elements "DRY"
3.  Experiment with the default Jquery validation plugin.
4.  Clean up all the if statements - far too many - regexs.
5.  Change the layout to a grid system instead of floats.
6.  Alert the user a submission has been succesfull
7.  Explore hiding the submit button until validated
8.  Create a custom control that displays inside the error
    message outside of the border or in a hidden grid cell
9.  Design a nicer background with jquery using a very subtle animation
10. Fix the problem with the password fields messages are confusing
    after the input box has changed - consider re-ordering
    the execution.
11. Some object null, empty, and event checking is required.
12.  Idealy some SQL injection and scriping removal in fields
    should be considered -security
13.  Accessabilty concerns should be looked.
14.  Add "new user" - navigate to a new user sign up page.
15.  PHP server side API and strict validation.
16. Creat a minfied version for mobile use.

*/

//IIFE
(function() {
  //declarations
  "strict";
  const on = "on";
  const off = "off";
  let allErrors = [];
  const allErrorMess = [
    //array of error messages for each type of error
    { id: 0, error: `Missing email`, type: `e` },
    { id: 1, error: `Missing @, or missing '.'`, type: `e` },
    { id: 2, error: `Duplicate '.' and '@'`, type: `m` },
    { id: 3, error: `Missing phone numbers or no numbers`, type: `m` },
    { id: 4, error: `There should <b><i>only</i></b> be 11 numbers!`,type: `m`},
    { id: 5, error: `too many numbers in phone number!`, type: `m` },
    { id: 6, error: `Please type in a valid number!`, type: `m` },
    { id: 7, error: `Password shorter than 8 characters!`, type: `p` },
    { id: 8, error: `Password box has no value!`, type: `p` },
    { id: 9, error: `Passwords do not match!`, type: `p` },
    { id: 10, error: `Confirm password box has no value!`, type: `pc` },
    { id: 11, error: `Password shorter than 8 characters!`, type: `p` },
    { id: 12, error: `Password is longer than 8 characters!`, type: `p` },
    { id: 13, error: `Confirm password box is longer than 8 characters!`, type: `pc`},
    { id: 14, error: `Confirm password box is shorter than 8 characters!`, type: `pc`}
  ];

  // function constructor to template the error messages
  //to be used later to inject the message into the element
  function ErrorMessage(theError) {
    this.errMessage = theError;
    this.allErrors = () => {
      console.log(`please correct - ${this.errMessage}`);
    };
  }

  //used with the validateEmail function
  function postsValidatedEmail() {
    if ($("#email").val().length === 0) {
      //sets the background
      sendState(on, "email");

      //adds the data to the array
      addDataAllErrors(allErrorMess[0]);
    } else if (!validateEmail($("#email").val())) {
      //sets the background
      sendState(on, "email");

      //adds the data to the array
      addDataAllErrors(allErrorMess[1]);

      //resets the email field
      $("#email").val("");
    } else {
      //Value validated put an element like a "tick"
      //image next to the element

      //sends the state and the object source
      sendState(off, "email");
      //clears the element
      $("#lblEmailError").html("");
      console.log(`the email element entered is correct!`);
    }
  }

  //validates an email address uses a regex.
  //('.test' is a built in js function)
  //returns the value to the caller
  function validateEmail($email) {
    //generates a regex expression to filter out illegals
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    //.test is a built in method
    return emailReg.test($email);
  }

  //validates the telephone number field - moves to checkNaN if successful
  function validatePhone() {
    //!$.trim(this.value).length - might be used later

    //tests for the length - (ternary exp), fails if 0
    //an adds an error message to the array
    $("#mobile").val().length > 0
      ? checkNaN($("#mobile").val()) // checks for bad values
      : helperValidatePhone(); // moves to the function;
  }

  //helper to the validatePhone() function
  function helperValidatePhone() {
    //sends the error state to change the background
    sendState(on, "phone");
    //adds the error to the array
    addDataAllErrors(allErrorMess[3]);
  }

  //used with the validatePhone() function
  function checkNaN() {
    //gets the input from the field,
    //cuts out any non numbers
    //and returns NaN if the first character is not a number
    let theActualVal = parseInt($("#mobile").val());

    //testing for not a number (Nan)
    //and then tests to see if the length is
    //correct after passing the NAN test
    if (!theActualVal) {
      //sets the background
      sendState(on, "phone");

      //adds the error message to the array
      addDataAllErrors(allErrorMess[6]);

      //clears the field
      clearPhone();
    } else if (
      $("#mobile").val().length < 11 ||
      $("#mobile").val().length > 11
    ) {
      //sets the background
      sendState(on, "phone");
      //adds the error message to the array
      addDataAllErrors(allErrorMess[4]);
      //clears the field
      clearPhone();
    } else {
      //sets the background of the mobile element
      sendState(off, "phone");

      //clears any error messages
      $("#lblPhoneError").html("");
      //diags
      console.log(`phone element validation - correct number of integers`);
    }
  }

  //clears the phone field when called
  function clearPhone() {
    $("#mobile").val("");
  }

  //Checks the password field for;
  //minimum lenght, no value,
  function validatePass() {
    //gets the elements length props
    let passW1 = $("#pass").val().length;
    let passW2 = $("#conpass").val().length;

    //checks for length short/long and null
    //no checking for illegal characters
    if (passW1 === 0) {
      //set the email element background by passing a state value
      sendState(on, "pass");

      //adds the error message to the array
      addDataAllErrors(allErrorMess[8]);
    } else if (passW2 === 0) {
      //sets the background
      sendState(on, "conpass"); //$('#conpass').css('background', 'yellow');

      //adds the error message to the array
      addDataAllErrors(allErrorMess[10]);
    } else if (!passInvalidLength(passW1) || !passInvalidLength(passW2)) {
      //adds the appropraite error message to the array
      //could be either to short, or too long. - "DRY" - a ternary exp
      if (passW1 > 8 || passW2 > 8) {
        if (passW1 > 8) {
          //sets the background - password too long or no value
          sendState(on, "pass");

          //adds the error message to the array - valid for both conditions
          addDataAllErrors(allErrorMess[12]);
        } else if (passW2 > 8) {
          //sets the background - password too long or no value
          sendState(on, "conpass");

          //adds the error message to the array - valid for both conditions
          addDataAllErrors(allErrorMess[13]);
        }
      } else {
        if (passW1 < 8) {
          //sets the background -  password too short
          sendState(on, "pass");
          addDataAllErrors(allErrorMess[11]);
        } else if (passW2 < 8) {
          //sets the background - confirm password too too short
          sendState(on, "conpass");
          addDataAllErrors(allErrorMess[14]);
        }
      }
    } else if (passW1 === passW2) {
      //checks for the same value - better way to do this!
      if ($("#pass").val() === $("#conpass").val()) {
        //resets the background
        sendState(off, "conpass");
        sendState(off, "pass");

        //removes the error messages
        $("#lblPassError").html("");
        $("#lblConPassError").html("");

        //diags to the console
        console.log(`password validation passed!`);
      } else {
        //adds the error message to the array, passwords don't match
        sendState(on, "conpass");
        sendState(on, "pass");
        addDataAllErrors(allErrorMess[9]);
      }
    }
  }

  //checks the length of the the password - called by ValidatePass()
  function passInvalidLength(thelength) {
    //assigns the variable
    let lengthIsCorrect = false;

    //ternary to check the length, if its
    //0 or less than 8 characters, then return false
    //can be false if its more than 8!
    let theBool =
      (thelength > 0 && thelength === 8) || thelength === 0
        ? (lengthIsCorrect = true)
        : (lengthIsCorrect = false);
    //returns back to to the caller
    return lengthIsCorrect;
  }

  //detects the state and the source and sets the background
  //of the effected elements
  function sendState(theState, theSource, theIndex) {
    //checks the sent state and which element to act upon
    if (theState === on) {
      //sets the background on error
      //console.log(theIndex);
      setbackonError(theSource, "yellow");
    } else if (theState === off) {
      //sets the background after positve validation
      setbackonError(theSource, "white");
    }
    else{
      //nothing happens!
    }
  }

  //sets the background of the detected element on detection of an error
  function setbackonError(theElement, thecolour) {
    //switch to detect the source element
    //and the colour to set the background
    //of the selected element

    switch (theElement) {
      case "email":
        $("#email").css("background", thecolour);
        break;
      case "phone":
        $("#mobile").css("background", thecolour);
        break;
      case "pass":
        $("#pass").css("background", thecolour);
        break;
      case "conpass":
        $("#conpass").css("background", thecolour);
        break;
      default:
        break;
    }
  }

  //adds an error message to the array
  function addDataAllErrors(theItem) {
    allErrors.push(theItem);

    return allErrors.lastIndexOf(theItem);
  }

  //removes an error message from the array
  function removeDataAllErrors() {
    allErrors.pop();
  }

  //helper to set the wrapper element from checkSubmissions
  function setWrapperAtts(thepixelSize) {
    $(".wrapper").css("width", thepixelSize);
  }

  //After submission check, alerts the user
  //of any problems
  function checkSubmission() {
    //checks the array for any values in
    //the allErrors array
    //displays any error messages
    console.log(allErrors.length);
    if (allErrors.length > 0 && allErrors.length <= 3) {
      //iterates the allErrors array
      allErrors.forEach(element => {
        //sets the width of the wrapper element
        //to accomodate the message errors
        setWrapperAtts("1000px");

        //tests to see which item will set the element
        if (element.type === "e") {
          $("#lblEmailError").html(element.error);
        } else if (element.type === "m") {
          $("#lblPhoneError").html(element.error);
        } else if (element.type === "p") {
          $("#lblPassError").html(element.error);
        } else if (element.type === "pc") {
          $("#lblConPassError").html(element.error);
        } else {
          //do nothing!
          console.log("is it a bug?");
        }
      });
    } else {
      //send all values to the server! - serialise
      setWrapperAtts("620px");

      //TODO = set a tick Icon next to the elements

      //diags
      console.log(`all values will be sent to the server`);
    }

    //removes the data from the array, for the next submission
    for (i = -1; i <= allErrors.length; i++) {
      //removes all the items in the array
      removeDataAllErrors();
    }
    //diags to display the array - should be 0 elements
    console.log(allErrors);
  }

  //change event for the input selector objects
  $("input").change(event => {
    //a switch  is used to detect the element id
    //is then used to run the corresponding
    //function - yuk what a mess!
    switch (event.target.id) {
      case "email":
        postsValidatedEmail();
        validatePhone();
        validatePass();
        break;
      case "mobile":
        validatePhone();
        validatePass();
        validateEmail();
        break;
      case "pass":
        validatePass();
        validateEmail();
        validatePhone();
        break;
      case "conpass":
        validatePass();
        validateEmail();
        validatePhone();
        break;
      default:
        break;
    }
    //reruns the submission
    checkSubmission();
  });

  //click event for btnsubmit element
  $("#btnsubmit").click(() => {
    //DIAG console.log(`click detected`);
    postsValidatedEmail();
    validatePhone();
    validatePass();
    checkSubmission();
  });
})();
