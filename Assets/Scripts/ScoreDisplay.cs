using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    //reference to the current score
    int currentScore;

    //use this to "fade" to the current score - this is what's displayed in scoreText.text.
    int scaleScore;

    [SerializeField]
    int scoreInc;

    Text scoreText;

    void Start() {
        currentScore = 0;
        scoreText = GetComponent<Text>();
    }

    void Update() {
        ScoreSlider();
    }

    void ScoreSlider() {
        //if current score isn't ScaleScore, increase it by an int
        if (currentScore != scaleScore) {
            scaleScore += scoreInc;
            //if it's above currentScore, make it equal to the currentScore
            if (scaleScore > currentScore) {
                scaleScore = currentScore;
            }
        }
        //then, make the text equal to a string version of the scaled Score
        scoreText.text = scaleScore.ToString();
    }

    public void ScoreUpdate(int scoreAdd) {
        //for use by DataCubePickup, to add score.
        currentScore += scoreAdd;
    }
}