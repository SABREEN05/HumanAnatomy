using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public Button[] answerButtons;
    public Button nextButton;
    public TextMeshProUGUI scoreText;

    private string[] questions = {
        "How many bones are there in the human hand?",
        "Which bone is located at the base of the thumb?",
        "The metacarpal bones are found in which part of the hand?",
        "How many phalanges are there in each finger, except the thumb?",
        "The bones in the fingers are called:",
        "Which bone is commonly known as the \"heel of the hand\"?",
        "The carpals are a group of how many bones in the wrist?",
        "The bone that forms the base of the little finger is called:",
        "The thumb contains how many phalanges?",
        "The bone that articulates with the radius to form the wrist joint is called:"
    };

    private string[][] answerChoices = {
        new string[] { "26", "27", "28", "29" },
        new string[] { "Scaphoid", "Trapezium", "Hamate", "Pisiform" },
        new string[] { "Palm", "Wrist", "Fingers", "Knuckles" },
        new string[] { "2", "3", " 4", "5" },
        new string[] { "Carpals", "Metacarpals", "Phalanges", "Radius" },
        new string[] { "Pisiform", "Hamate", "Trapezium", "Capitate" },
        new string[] { "5", "6", "7", "8" },
        new string[] { "Hamate", "Trapezium", "Scaphoid", "Triquetrum" },
        new string[] { "1", "2", "3", "4" },
        new string[] { "Scaphoid", "Lunate", "Triquetrum", "Pisiform" }
    };

    private int[] correctAnswers = { 0, 1, 0, 1, 2, 3, 3, 0, 1, 1 };


    private int currentQuestionIndex;
    private int correctAnswersCount;

    void Start()
    {
        currentQuestionIndex = 0;
        correctAnswersCount = 0;
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        questionText.text = questions[currentQuestionIndex];

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = answerChoices[currentQuestionIndex][i];
        }

        nextButton.interactable = false;
    }

    public void OnAnswerSelected(int answerIndex)
    {
        if (answerIndex == correctAnswers[currentQuestionIndex])
        {
            Debug.Log("Correct! Moving to the next question.");
            correctAnswersCount++;

        }
        else
        {
            Debug.Log("Incorrect! Please try again.");
        }

        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Length)
        {
            DisplayQuestion();
        }
        else
        {
            Debug.Log("Quiz completed!");
            ShowScore();
        }
    }

    void ShowScore()
    {
        int totalQuestions = questions.Length;
        float percentage = (float)correctAnswersCount / totalQuestions * 100f;

        // Display the score
        scoreText.text = "Score: " + correctAnswersCount + " / " + totalQuestions + " (" + percentage.ToString("F2") + "%)";
    }

    public void OnNextButtonClick()
    {
        nextButton.interactable = false;
    }
}