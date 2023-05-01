using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceen : MonoBehaviour
{
[SerializeField] TextMeshProUGUI finalScoreText;
ScoreKeeper scoreKeeper;

void Awake() {
    scoreKeeper = FindObjectOfType<ScoreKeeper>();
}
public void ShowFinalScore(){
    finalScoreText.text = "congrats" + scoreKeeper.CalculateScore();
}

}
