/* Quiz Game */

/* Js code and Query code designed by C.Coulson 03/04/19 */

/* The game will;
  0. Checks that the Quiz Start button is pressed
     and does not allow input to be propagated
     into the game until the button is pressed
  --Button is pressed and the following sequnce of events is performed--
  1. randomly selects a datastore.
  2. randomly select a question from the selected datastore.
  3. Displays that question to the UI.
  4. Display the multiple choice answers.
  5. Waits for input, when valid the input 
     is compared with the datastore correct answer.
     Illegal characters will not be proccessed.
  6. If the answer is correct the correct score is updated
     and the next random question is displayed along
     with the multiple choice answers.
  7.If the answer is incorrect, the incorrect score is dispayed
    and the correct score is decremented, the next random 
    question is displayed along with the multiple choice answers.
  8.When all of the questions have been displayed from the datastore
    the game will display the players stats and display them
    in the center element.
  9.The button and the input textbox are deactivated.
  10.The browser will need to be refreshed to play again

*/

/* DRY = dont repeat yourself */

/* To DO 
  1. Fix the quiz button so it does not display all of the questions!
  2. Create properties for the HMTL element classNames or Id's reduces coding errors
  3. Fix the inteval timer.*** FIXED ***
  4. Use closures, ...spread operators?
  5. Fix the Area Textbox element so it resizes properly and,
     fix the control so you cannot edit it. 
  6. Add a media query to set the minified aspect of the page
  7. Use Jquery for animations/effects etc
  8. Add a pop up box to congratulate the user and show an animated image
     with some fireworks in the background (or comiserates the user!).
  9. Detect the browser. 
  10.Set of tools to deal with mobile and tablets (maybe bootstrap?).
  11.Create an API to access a sqlite database instead of hard coding values.
  12.Consider the MVC pattern to split the data / UI / and Control into 3 objects
     that can be called from outside if neccessary.
  13.Reduce the code in the function extractAnswers() and move similar 
     operations into functions to reduce DRY.
  14.Add alt attributes - accesability.
*/

//IIFE
(function() {
  //declarations
  "use strict";
  let rightAnswer = 0;
  let thenumber = 0;
  let theStoreId = 0;
  let wrongAnswer = 0;
  let programLoop = 0;
  let answer;
  let questionIds = [];
  const finnishedQuiz = 8;
  const questionsStore = [];
  const theQuestionArray = [
    {
      question: "Which car won the 1977 european car of the year award?",
      questionsArray: ["Rover Sd1", "VW golf", "Lambourghini Urracco"],
      correctAnswer: 0
    },
    {
      question: "Which film star won an oscar for Gone with the wind?",
      questionsArray: ["Gregory Peck", "Vivien Leigh", "Charlton Heston"],
      correctAnswer: 1
    },
    {
      question:
        "Which pop artist in 1984 had the most weeks in the top ten in the UK?",
      questionsArray: ["Madadona", "Franky goes to hollywood", "Lionel Richie"],
      correctAnswer: 1
    },
    {
      question: "Which Year was the last flight of concorde?",
      questionsArray: ["2002", "1999", "2003"],
      correctAnswer: 2
    },
    {
      question: 'Which the actor played "strider" in the Lord of the rings?',
      questionsArray: ["Vigo Mortensen", "Billy Boyd", "Sean Bean"],
      correctAnswer: 0
    },
    {
      question:
        "Who scored the highest number of goals in the champions league?",
      questionsArray: ["Zinedine Zidane", "Maradona", "Cristiano Ronaldo"],
      correctAnswer: 2
    },
    {
      question:
        "Which politician said 'The Press make fake news...it's all the time?",
      questionsArray: ["Hugo Chavez", "Moshe Dian", "Donald Trump"],
      correctAnswer: 2
    }
  ];
  const theCarQuestionArray = [
    {
      question: "Which car is 'Herbie'?",
      questionsArray: ["Fiat 500", "VW beetle", "Ferrari Dino"],
      correctAnswer: 1
    },
    {
      question: "Which road car had six wheels in 1979?",
      questionsArray: ["Tyrell F1", "Panther 6", "Humber Fox"],
      correctAnswer: 1
    },
    {
      question: "Which new car in May 1980 cost £58,392?",
      questionsArray: [
        "Mercedes 450SEL 6.9",
        "Aston Martin Lagonda",
        "Rolls Royce Corniche"
      ],
      correctAnswer: 2
    },
    {
      question:
        "Which car was the first all new Jaguar under Fords new ownership?",
      questionsArray: ["X-type", "S-type", "XJ6"],
      correctAnswer: 1
    },
    {
      question: "Who made the first Mass market electric vehicle?",
      questionsArray: ["Nissan", "General Motors", "Tesla"],
      correctAnswer: 1
    },
    {
      question: "Which was the fastest road car by top speed in 2003?",
      questionsArray: ["Lamborghini Diabolo", "Buggatti Vyron", "Zonda Pagini"],
      correctAnswer: 1
    },
    {
      question: "Which car won the car of the year award in 2009?",
      questionsArray: ["Hyundai I30", "Honda Civic", "Ford Focus"],
      correctAnswer: 0
    }
  ];
  const theGeneralKnowArray=[];

  //Selects which question array to use - not used
  function selectQuestionStore() {
    //gets the items of the array using a map function
    questionsStore.map(current => {
      //console.log(`the id is ${currentid} and the array is ${current.nameOfArray}`);
      //console.log(theStoreId);
      //console.log(current[theStoreId]);
    });
  }

  //simple jquery animation
  function animateElement(){
    
  }

  //populates the quiz arrays into one array
  function addQuestionStore() {
    //adds the arrays to this array if the array length is 0
    if (questionsStore.length === 0) {
      questionsStore.push(theQuestionArray);
      questionsStore.push(theCarQuestionArray);
    }
  }

  //Matches the answer to the answer stored
  //Sets the HTML elements values
  //Activates a setInteval timer event for effects on two elements
  function extractAnswers() {
    //compares the answer from the html element with the property value in the array.
    if (answer === questionsStore[theStoreId][thenumber].correctAnswer) {
      //increments the rightAnswer variable to record the scores
      rightAnswer++;

      //sets the text on the HTML control - change to Jquery!
      document.querySelector(".lblCorrectStatus").innerHTML = `that's the correct answer!`;

      //sets a timer that changes an element
      //****FAULT --> needs to be moved****
      //for additional checking for multiple setInterval timeout calls
      //are removed, and preserves the original interval time.
      /*       setInterval(()=>{
        document.querySelector(".lblCorrectStatus").innerHTML = "";
      }, 5000); */

      //this seems to work better and controls the program flow
      //fades out the content in the element within specified time
      $(".lblCorrectStatus").fadeOut(2000, () => {
        //fades in the content after 10ms and clears the element
        //and resets other elements - "this" does not work.
        $(".lblCorrectStatus").fadeIn(10, () => {
          //clears the element
          $(".lblCorrectStatus").html("");
          //sets the value for the score
          $(".lblCorrectScore").html(rightAnswer);
          //document.querySelector(".lblCorrectScore").innerHTML = rightAnswer;
          $(".lblIncorrectStatus").html("");
          //document.querySelector(".lblIncorrectStatus").innerHTML = "";
          $(".inpYourAns").val("");
          //document.querySelector(".inpYourAns").value = "";

          //moves to the next question.
          nextQuestion();
        });
      });
    } else {
      //increments the wrongAnswer variable to record the scores
      wrongAnswer++;
      //checks the right answer, decrements the score
      if (rightAnswer > 0) {
        rightAnswer--;
        document.querySelector(".lblCorrectScore").innerHTML = rightAnswer;
        //console.log(rightAnswer);
      }
      //sets the variables within the elements change this to JQuery!
      //document.querySelector(".lblIncorrectScore").innerHTML = wrongAnswer;
      document.querySelector(".lblIncorrectStatus").innerHTML = `Incorrect - try again!`;

      //Fades out the element
      $(".lblIncorrectStatus").fadeOut(2000, () => {
        //fades in the element and clears the values
        $(".lblIncorrectStatus").fadeIn(10, () => {
          //sets the element values
          $(".lblIncorrectStatus").html("");
          $(".lblIncorrectScore").html(wrongAnswer);
          //resets all the elements
          $(".lblCorrectStatus").html("");
          $(".inpYourAns").val("");
          //moves the focus
          document.querySelector(".inpYourAns").focus();
          //moves to the nextQuestion method
          nextQuestion();
        });
      });
    }
  }

  //Function Displays a random question
  function displayQuestions(id) {
    //sets the next question and populates the html controls.
    //console.log(id);
    let textAreaArry = [];
    if (id < 7) {
      //sets the element content/text - for the question text
      document.querySelector(".lblQuestion").innerHTML =
        questionsStore[theStoreId][id].question;

      //loops through the questionArray object for each question index.
      //train wreck code should be in a variable!
      for (var i = 0;i < questionsStore[theStoreId][id].questionsArray.length; i++) {
        //diags.
        //console.log("the object is " + theQuestionArray[id].questionsArray[i]);

        //adds the multiple choice answers.
        textAreaArry.push(
          "\n" + i + ":" + questionsStore[theStoreId][id].questionsArray[i]
        );
      }

      //diags.
      //console.log(textAreaArry);

      //sets all the controls
      document.getElementById("questionid").textContent = textAreaArry;
      document.querySelector(".inpYourAns").focus();
    } else if (id > 7) {
      //if all of the questions have been displayed,
      //add message to the HTML element
      document.getElementById("questionid").textContent = `The quiz has ended! 
          \nyou answered correctly ${rightAnswer} questions
          \nand incorrectly ${wrongAnswer}`;

      //resets the variables deactivates event listners.
      document
        .querySelector(".inpYourAns")
        .removeEventListener("change", getInput);
      document
        .querySelector(".btnStartQuiz")
        .removeEventListener("change", getButton);
      rightAnswer = 0;
      wrongAnswer = 0;
    } else {
      //do nothing, there is more execution after the end of the program due to
      //unfinnished calls to the nextQuestions() function.
    }
  }

  //function returns a random number to select a random data store
  function returnDataStoreId() {
    //generates a random rounded number variable
    //for future data store selection derived from the
    //data stores lenght.
    if (programLoop === 0) {
      //generates a rounded integer
      theStoreId = Math.floor(Math.random() * questionsStore.length);
      //diags
      console.log(`the random number is ${theStoreId}`);
      //updates the variable, stops the prog from adding datastores
      programLoop++;
    }
  }

  //Function generates a random number and checks the program flow
  function returnRandomNumber() {
    //diags
    console.log("the size of array is " + questionsStore[theStoreId].length);

    //generates a random rounded number,for selecting the index of a question.
    thenumber = Math.floor(Math.random() * questionsStore[theStoreId].length);

    //checks the array by index, to avoid repeating the same question.
    //returns -1 if not found.
    let theindex = questionIds.findIndex(x => x === thenumber);

    //diags
    //console.log(theindex);

    if (theindex !== -1 && questionIds.length < 7) {
      //the same number was found.
      console.log(`the same number was found`);
      //runs the cycle again.
      nextQuestion();
    } else if (questionIds.length < 7) {
      //adds the number to the array for tracking the same numbers.
      questionIds.push(thenumber);
      //sends the number to the function
      return thenumber;
    } else {
      //end of the quiz detected.
      return finnishedQuiz;
    }
  }

  /* timer object not implemented yet to solve DRY */
  function elementTxtTimer(theElement) {
    //use jquery instead.
    setInterval(() => {
      document.querySelector(theElement).innerHTML = "test";
    }, 3000);
  }

  //moves to the method after integer randomisation
  //and moves to display the question based on the integer generated.
  function nextQuestion() {
    //called from the extractAnswers function
    displayQuestions(returnRandomNumber());
  }

  //entry point of the application.
  function startProgram() {
    //"use strict";
    //starts the app and moves to the functions
    addQuestionStore();
    returnDataStoreId();
    nextQuestion();
  }

  //from the eventlistener function
  //gets the data from "inpYourAns" element,
  //extracts the value.
  function getInput() {
    //assigns the input value, parses to an integer
    answer = parseInt(document.querySelector(".inpYourAns").value);

    //assigns the variable of the content in the element
    let emptyBox = document.querySelector("#questionid").textContent;

    //diags
    //console.log(emptyBox);//should be null here for the first time.

    //checks the areaText content length, incase a value is entered before
    //pressing the button.
    if (emptyBox.length > 0) {
      //diags
      //console.log(answer);
      extractAnswers();
    } else {
      //diags
      console.log("the startquiz button was not pressed");
      //alert("the startquiz button was not pressed")

      //resets the values in the elements
      document.querySelector(".divFooter").innerHTML =
        "the StartQuiz button was not pressed!";
      document.querySelector(".inpYourAns").value = "";
    }
  }

  //from the eventlistener function 
  //element "btnStartQuiz", starts the app.
  function getButton() {
    //consider a ternary here
    //checks the content applied to the html element and clears it.
    if (document.querySelector(".divFooter").innerHTML.length === 0) {
      //moves to the function.
      startProgram();
    } else {
      //resets the element and moves to the function.
      document.querySelector(".divFooter").innerHTML = "";
      startProgram();
    }
  }

  //gets the input and runs the "extractAnswer" func
  document.querySelector(".inpYourAns").addEventListener("change", getInput);

  //"start quiz" button assigned an event listener
  document.querySelector(".btnStartQuiz").addEventListener("click", getButton);
})();