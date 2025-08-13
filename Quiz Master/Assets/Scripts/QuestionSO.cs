using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string quesiton = "Enter new question here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctIdx = 0;
    public string GetQuestion()
    {
        return quesiton;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctIdx;
    }

    public string GetAnswer(int idx)
    {
        return answers[idx];
    }
}
