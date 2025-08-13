using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float timeLimit = 30f; // Time limit in seconds
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    [SerializeField] GameObject timerUI; // Reference to the UI element that displays the timer
    public bool isAnsweringQuestion = false;
    public float fillFraction;
    float timerValue = 0;
    public bool loadNextQuestion = false;
    void Update()
    {
        UpdateTimer();
        
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion) // 정답을 골랐나?
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeLimit;
            }
            else //고르지 못했으면 정답을 보여줌
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (timerValue > 0) //정답을 보여주는 시간
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else //다시 30초 타이머로 바꾸고 다음 문제 출력
            {
                isAnsweringQuestion = true;
                timerValue = timeLimit;
                loadNextQuestion = true;
            }
        }

        Debug.Log(timerValue);
    }
}
