using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    int currentScore;
    int scaleScore;
    Text scoreText;

    void Start() {
        currentScore = 0;
        scoreText = GetComponent<Text>();
    }

    void Update() {
        ScoreSlider();
    }

    void ScoreSlider() {
        if (currentScore > scaleScore) {
            scaleScore += 111;
        }
        if (scaleScore > currentScore) {
            scaleScore = currentScore;
        }
        scoreText.text = scaleScore.ToString();
    }

    public void ScoreUpdate(int scoreAdd) {
        currentScore += scoreAdd;
    }
}