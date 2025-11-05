using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using System;

public class CapaQuiz : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string question;
        public string answer;
    }

    [System.Serializable]
    public class QuestionList
    {
        public List<Question> questions;
    }

    public TextMeshProUGUI questionText;
    public TMP_InputField answerInput;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private List<Question> questions;
    private Question currentQuestion;
    private int score = 0;
    private int highScore = 0;

    void Start()
    {
        questions = new List<Question>();
        LoadQuestionsFromJSON();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;

        if (questions.Count > 0)
        {
            DisplayRandomQuestion();
        }
    }

    void LoadQuestionsFromJSON()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "CapaQuiz.json");
        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            QuestionList questionList = JsonUtility.FromJson<QuestionList>(jsonString);
            questions = questionList.questions;
        }
        else
        {
            Debug.LogError("File not found: " + path);
        }
    }

    void DisplayRandomQuestion()
    {
        if (questions.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, questions.Count);
            currentQuestion = questions[randomIndex];
            questionText.text = currentQuestion.question;
            answerInput.text = "";
        }
        else
        {
            questionText.text = "Quiz completed!";
            answerInput.gameObject.SetActive(false);
        }
    }

    public void CheckAnswer()
    {
        if (currentQuestion != null)
        {
            string userAnswer = answerInput.text;
            if (userAnswer.Equals(currentQuestion.answer, System.StringComparison.OrdinalIgnoreCase))
            {
                score++;
                scoreText.text = "Score: " + score;

                if (score > highScore)
                {
                    highScore = score;
                    PlayerPrefs.SetInt("HighScore", highScore);
                    highScoreText.text = "High Score: " + highScore;
                }
            }

            // Remove the answered question to avoid repetition
            questions.Remove(currentQuestion);

            DisplayRandomQuestion();
        }
    }
}

