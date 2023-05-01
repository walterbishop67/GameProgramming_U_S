using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Questions", fileName = "New Question")]
public class QuestionsSO : ScriptableObject {
    [TextArea(2,4)]
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;
    public string GetQuestion() {
        return question;
    }
    public int GetCorrectAnswerIndex() {
        return correctAnswerIndex;
    }
    public string GetAnswer(int index){
        if(index >= 0 && index < answers.Length)
            return answers[index];
        return null;
    }
}

