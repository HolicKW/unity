using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] QuestionSO questions;
    [SerializeField] TextMeshProUGUI questionText;
    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctIndex;
    bool hasAnsweredEarly;
    [Header("Buttons")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        getNextQuestion();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            getNextQuestion();
            timer.loadNextQuestion = false;
        }
    }

    public void onAnswerSelected(int index)
    {
        Image buttonImage;
        if (index == questions.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctIndex = questions.GetCorrectAnswerIndex();
            buttonImage = answerButtons[correctIndex].GetComponent<Image>();
            questionText.text = "Sorry, the answer was :\n" + questions.GetAnswer(correctIndex);
            buttonImage.sprite = correctAnswerSprite;
        }
        setBtnState(false);
        timer.CancelTimer();
    }

    void displayQuestion()
    {
        questionText.text = questions.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonTexts = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonTexts.text = questions.GetAnswer(i);
        }
    }

    void setBtnState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void getNextQuestion()
    {
        setBtnState(true);
        setDefaultButtonSprites();
        displayQuestion();
    }
    void setDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
