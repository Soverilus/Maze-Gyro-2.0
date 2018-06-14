using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class WinLoseScript : MonoBehaviour {

    public GameObject[] winObjects;
    public GameObject[] loseObjects;

    // Use this for initialization
    void Start() {
        Time.timeScale = 1;
        HideWin();
        HideLose();

    }


    //Reloads the Level
    void Reload() {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    //shows objects with ShowOnWin tag
    void ShowWin() {
        foreach (GameObject g in winObjects) {
            g.SetActive(true);

        }
    }

    //hides objects with ShowOnWin tag
    void HideWin() {
        foreach (GameObject g in winObjects) {
            g.SetActive(false);
        }
    }

    //shows objects with ShowOnLose tag
    void ShowLose() {
        foreach (GameObject g in loseObjects) {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnLose tag
    void HideLose() {
        foreach (GameObject g in loseObjects) {
            g.SetActive(false);
        }
    }

    //Pauses the game
    void Pause() {
        Time.timeScale = 0;
    }

    public void Win() {
        //Add Win condition here
        Pause();
        ShowWin();
    }

    public void Lose() {
        //Add Lose condition here
        Pause();
        ShowLose();
    }
}
