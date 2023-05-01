using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    float timerValue;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion = false;
    public float fillFriction;

    void Update() {
        UpdateTimer();
    }

    public void CancelTimer(){
        timerValue = 0;
    }
    void UpdateTimer(){
        timerValue -= Time.deltaTime;
        if(isAnsweringQuestion){
            if(timerValue > 0){
                fillFriction = timerValue / timeToCompleteQuestion;
            }
            else{
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }else{
            if(timerValue > 0){
                fillFriction = timerValue / timeToShowCorrectAnswer;
            }
            else{
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
            
        }
    }
}
