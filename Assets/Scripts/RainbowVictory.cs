using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class RainbowVictory : MonoBehaviour {
    SpriteRenderer mySPR;

    [SerializeField]
    Canvas winLose;

    [SerializeField]
    float timerMult;

    [SerializeField]
    float timerCount;
    float timer = 0f;
    int rainbowSect = 0;
    Color currentTargetColor;

    void Start() {
        mySPR = GetComponent<SpriteRenderer>();

    }

    void Update() {
        //CurrentTargetColorParse();
        //RainbowColorChange(currentTargetColor);
    }

    /*void RainbowColorChange(Color color) {
        CurrentTargetColorParse();
        timer += Time.deltaTime * timerMult;
        mySPR.color = Color.Lerp(mySPR.color, color, timer);
        if (timer >= timerCount) {
            timer = 0f;
            rainbowSect += 1;
        }
    }

    void CurrentTargetColorParse() {
        if (rainbowSect == 0) {
            currentTargetColor = new Color(1f, 0f, 0f);
        }
        if (rainbowSect == 1) {
            currentTargetColor = new Color(1f, 0.5f, 0f);
        }
        if (rainbowSect == 2) {
            currentTargetColor = new Color(1f, 1f, 0f);
        }
        if (rainbowSect == 3) {
            currentTargetColor = new Color(0.5f, 1f, 0f);
        }
        if (rainbowSect == 4) {
            currentTargetColor = new Color(0f, 1f, 0f);
        }
        if (rainbowSect == 5) {
            currentTargetColor = new Color(0f, 1f, 0.5f);
        }
        if (rainbowSect == 6) {
            currentTargetColor = new Color(0f, 1f, 1f);
        }
        if (rainbowSect == 7) {
            currentTargetColor = new Color(0f, 0.5f, 1f);
        }
        if (rainbowSect == 8) {
            currentTargetColor = new Color(0f, 0f, 1f);
        }
        if (rainbowSect == 9) {
            currentTargetColor = new Color(0.5f, 0f, 1f);
        }
        if (rainbowSect == 10) {
            currentTargetColor = new Color(1f, 0f, 1f);
        }
        if (rainbowSect == 11) {
            currentTargetColor = new Color(1f, 0f, 0.5f);
        }
        if (rainbowSect >= 12) {
            rainbowSect = 0;
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == ("Player")) {
            //do victory
        }
    }
}
