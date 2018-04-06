using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour {

    public List<Button> letterButtons = new List<Button>();
    List<Letter> lettersToTest = new List<Letter>();
    Letter currentLetter;
    Question currentQuestion;
    public Text correctText, incorrectText;
    public int correctInt, incorrectInt;
    public int delayUntilNextQuestion = 3;
    public GameObject questionTitle;
    public GameObject[] questionAnswerButtons;
    public Color letterSelectedColour, letterDeselectedColour, answerCorrectColour, answerIncorrectColour, answerNormalColour;
    public GameObject lettersContainer, questionContainer;

   // private void Start()    // If used it will make the assigned 'LettersContainer" be the first page of the new scene which we do not want //
    //{
       // lettersContainer.SetActive(true);
        //questionContainer.SetActive(false);
    //}

    public void NewLetterTest()
    {
        currentLetter = lettersToTest[Random.Range(0, lettersToTest.Count - 1)];

        currentQuestion = currentLetter.questions[Random.Range(0, currentLetter.questions.Count - 1)]; //Note that the -1 means that if you wanted 2 possible questions for, you would need to assign 3, otherwise the same question would appear for the targeted letter // 

        questionTitle.GetComponent<Text>().text = currentQuestion.title;  // Assigning the Title value of the Buttons Script to the Text display in the Test Page //
        
        for (int i = 0; i < currentQuestion.answers.Length; i++)
        {
            questionAnswerButtons[i].GetComponentInChildren<Text>().text = currentQuestion.answers[i];  //Inputting the value of the Selectetion buttons Scripts to the 4 Answer Buttons in the test page //
        }
    }

    public void QuestionAnswered()
    {
        lettersToTest.Remove(currentLetter);      // Reduces to the letter amount and removes the specific letter just answered //
        currentQuestion = null;

        foreach (GameObject answerButton in questionAnswerButtons)
        {
            answerButton.GetComponent<Image>().color = answerNormalColour;
        }

        if (lettersToTest.Count > 0)                   // If there are still letters loaded for Questions, continue the test page //
        {
            NewLetterTest();
        }
        else
        {
            lettersContainer.SetActive(true);               // Opening the Selection Page //
            foreach (Button button in letterButtons)
            {
                button.GetComponent<Image>().color = letterDeselectedColour; //Resetting the green cards that where selected for testing back to white //
            }

            
            questionContainer.SetActive(false);       // Closing the test page //
            correctInt = 0;                        // resetting the number value of the correct Scoreboard object //
            correctText.text = correctInt.ToString();    // resetting the string and display text of the correct Scoreboard object //
            incorrectInt = 0;                          // resetting the number value of the incorrect Scoreboard object //
            incorrectText.text = incorrectInt.ToString();         // resetting the string and display text of the incorrect Scoreboard object //

        }
    }

    public void LetterPressed(Letter letter)
    {
        if (lettersToTest.Contains(letter))   //Means if the letter on the Selection page is already Selection and green //
        {
            lettersToTest.Remove(letter);      // Deselect the letter //
            letter.GetComponentInParent<Image>().color = letterDeselectedColour; // Turn the card back to white //
        }
        else
        {
            lettersToTest.Add(letter);      // Select the letter and add it to the Question array amount //
            letter.GetComponentInParent<Image>().color = letterSelectedColour; // Display the letter card green //
        }
    }

    public void AnswerPressed(Button button)
    {
        if (button.GetComponentInChildren<Text>().text == currentQuestion.correctAnswer) // if the assigned value of the correct answeer in Question class matches the assigned button value then run function //
        {
            correctInt++;                                          // Adding an increased value of one to the Correct int attached to the String Text for the Scorebaord //
            correctText.text = correctInt.ToString();
            button.GetComponent<Image>().color = answerCorrectColour;   // Turn selected answer Button Green //
            Invoke("QuestionAnswered", delayUntilNextQuestion);
        }
        else
        {
            incorrectInt++;                                     // Adding an increased value of one to the Incorrect int attached to the String Text for the Scorebaord //
            incorrectText.text = incorrectInt.ToString();
            button.GetComponent<Image>().color = answerIncorrectColour;      // Turns the selected wrong answer button red //

            foreach (GameObject answerButton in questionAnswerButtons)
            {
                if(answerButton.GetComponentInChildren<Text>().text == currentQuestion.correctAnswer)
                {
                    answerButton.GetComponent<Image>().color = answerCorrectColour;   // Turns the correct answer green if the player selected the wrong answer //
                    break;
                }
            }

            Invoke("QuestionAnswered", delayUntilNextQuestion); // Wait 3 seconds (set in variable at top) until the Question Title and Answer buttons text changes as awell as the Correct answer letter //
        }
    }

    public void StartTest()
    {
        if(lettersToTest.Count > 0)
        {
            lettersContainer.SetActive(false);    // The assigned Page object named LettersContainer, in the Question Controller Object, is clossed /
            questionContainer.SetActive(true);   // The assigned Page object named Question Container, in the Question Controller Object, is opened /
            NewLetterTest();
        }
    }

    public void CancelButton()        // A seperate function is needed for the Cancel button despite it achieveing the same as the end of test in function QuestionAnswered //
    {

        lettersToTest.Clear(); // This clears any remaining Questions that have not been asked and answer by the user before the Cancel Button was pressed //
        lettersContainer.SetActive(true);              // The assigned Page named LettersContainer, in the Question Controller Object, is clossed //
        foreach (Button button in letterButtons)       // Foreach needed as the number of letters selected by the users varies //
        {
            button.GetComponent<Image>().color = letterDeselectedColour;   // Resetting the Letter card in the Selection page back to white //
        }

        questionContainer.SetActive(false);    // Closing the test page //
        correctInt = 0;                             // resetting the number value of the correct Scoreboard object //
        correctText.text = correctInt.ToString();   // resetting the string and display text of the correct Scoreboard object //
        incorrectInt = 0;                             // resetting the number value of the incorrect Scoreboard object //
        incorrectText.text = incorrectInt.ToString();  // resetting the string and display text of the incorrect Scoreboard object //
    }

    
}
