using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour {

    public List<Button> letterButtons = new List<Button>();
    List<Letter> lettersToTest = new List<Letter>();
    Letter currentLetter;
    Question currentQuestion;
    public int score = 0;
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

        currentQuestion = currentLetter.questions[Random.Range(0, currentLetter.questions.Count - 1)];

        questionTitle.GetComponent<Text>().text = currentQuestion.title;
        
        for (int i = 0; i < currentQuestion.answers.Length; i++)
        {
            questionAnswerButtons[i].GetComponentInChildren<Text>().text = currentQuestion.answers[i];
        }
    }

    public void QuestionAnswered()
    {
        lettersToTest.Remove(currentLetter);
        currentQuestion = null;

        foreach (GameObject answerButton in questionAnswerButtons)
        {
            answerButton.GetComponent<Image>().color = answerNormalColour;
        }

        if (lettersToTest.Count > 0)
        {
            NewLetterTest();
        }
        else
        {
            foreach (Button button in letterButtons)
            {
                button.GetComponent<Image>().color = letterDeselectedColour;
            }

            score = 0;
            lettersContainer.SetActive(true);
            questionContainer.SetActive(false);
        }
    }

    public void LetterPressed(Letter letter)
    {
        if (lettersToTest.Contains(letter))
        {
            lettersToTest.Remove(letter);
            letter.GetComponentInParent<Image>().color = letterDeselectedColour;
        }
        else
        {
            lettersToTest.Add(letter);
            letter.GetComponentInParent<Image>().color = letterSelectedColour;
        }
    }

    public void AnswerPressed(Button button)
    {
        if (button.GetComponentInChildren<Text>().text == currentQuestion.correctAnswer)
        {
            score++;
            button.GetComponent<Image>().color = answerCorrectColour;
            Invoke("QuestionAnswered", delayUntilNextQuestion);
        }
        else
        {
            button.GetComponent<Image>().color = answerIncorrectColour;

            foreach (GameObject answerButton in questionAnswerButtons)
            {
                if(answerButton.GetComponentInChildren<Text>().text == currentQuestion.correctAnswer)
                {
                    answerButton.GetComponent<Image>().color = answerCorrectColour;
                    break;
                }
            }

            Invoke("QuestionAnswered", delayUntilNextQuestion);
        }
    }

    public void StartTest()
    {
        if(lettersToTest.Count > 0)
        {
            lettersContainer.SetActive(false);
            questionContainer.SetActive(true);
            NewLetterTest();
        }
    }
}
