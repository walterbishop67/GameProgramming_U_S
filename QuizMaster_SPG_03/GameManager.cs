using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Answer quiz;
    EndSceen endSceen;
    ScoreKeeper scoreKeeper;
   
   void Awake(){
        quiz.gameObject.SetActive(true);
        endSceen.gameObject.SetActive(false);
   }
    void Start()
    {
        quiz = FindObjectOfType<Answer>();
        endSceen = FindObjectOfType<EndSceen>();

        
    }

   
    void Update()
    {
        Screen();
    }
    public void Screen(){
        if(quiz.isCopmlete){
            quiz.gameObject.SetActive(false);
            endSceen.gameObject.SetActive(true);
            endSceen.ShowFinalScore();
        }
    
    }
    public void OnReplayLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
