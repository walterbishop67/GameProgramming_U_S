using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{   
    [Header("Question")]
    [SerializeField] TextMeshProUGUI questionText;
    QuestionsSO currentQuestion;
    public List<QuestionsSO> questions = new List<QuestionsSO>();

    [Header("Answer")]
    [SerializeField] GameObject[] answersButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header("Button")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    Image buttonImage;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    public bool isCopmlete;
    
    void Awake()
    {
        
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
       
        
    }
    void Update() {
        timerImage.fillAmount = timer.fillFriction;
        if(timer.loadNextQuestion){
            if(progressBar.value == progressBar.maxValue){
                isCopmlete = true;
                return;
            }

            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion= false;
        }else if(!hasAnsweredEarly && !timer.isAnsweringQuestion){
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    public void OnAnswerSelected(int index){
        
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "score" + scoreKeeper.CalculateScore() + "%";

      
    
    }

    void DisplayAnswer(int index){
        
        if(index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answersButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {   
            correctAnswerIndex  = currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry the correct answer is \n" + correctAnswer;
            buttonImage = answersButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

    }
    void GetNextQuestion(){
        if(questions.Count > 0){
            SetButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            DisplayQuestions();
            progressBar.value++;
            scoreKeeper.IncrementQuestionSeen();
        }
        
    }
    void GetRandomQuestion(){
        
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if(questions.Contains(currentQuestion)){
            questions.Remove(currentQuestion);
        }
        
    }

    void DisplayQuestions(){
        questionText.text = currentQuestion.GetQuestion();
        
        for(int i = 0; i < answersButtons.Length; i++){
            TextMeshProUGUI buttonText = answersButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }
    void SetButtonState(bool state){
        for(int i = 0; i < answersButtons.Length; i++){
            Button button = answersButtons[i].GetComponent<Button>();
            button.interactable = state;
        }

    }
    void SetDefaultButtonSprite(){
        for(int i = 0; i < answersButtons.Length; i++){
            buttonImage = answersButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
