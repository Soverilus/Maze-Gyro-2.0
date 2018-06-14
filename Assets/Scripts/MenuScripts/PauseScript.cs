using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public GameObject[] pauseObjects;


    void Start() {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        HidePaused();
    }

    void Update() {

        //uses the p button to pause and unpause the game
        if (SystemInfo.supportsAccelerometer) {
            if (Input.touchCount > 0) {
                if (Time.timeScale == 1) {
                    Time.timeScale = 0;
                    ShowPaused();
                    //shows the cursor during pause
                }
            }
        }
        else if (Input.GetButtonDown("Cancel")) {
            if (Time.timeScale == 1) {
                Time.timeScale = 0;
                ShowPaused();
                //shows the cursor during pause
            }
        }

    }


    //Reloads the Level
    public void Reload() {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //controls the pausing of the scene
    /*void pauseControl() {
        if (Time.timeScale == 1) {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0) {
            Time.timeScale = 1;
            hidePaused();
        }
    }*/

    //shows objects with ShowOnPause tag
    public void ShowPaused() {
        foreach (GameObject g in pauseObjects) {
            g.SetActive(true);
            AudioListener.volume = 0f;
        }
    }

    //hides objects with ShowOnPause tag
    public void HidePaused() {
        if (Time.timeScale == 0) {
            //Debug.Log("high");
            Time.timeScale = 1;
            AudioListener.volume = 1f;
        }
        foreach (GameObject g in pauseObjects) {
            g.SetActive(false);
        }
    }


    /*//Pauses the game
    void Pause() {
        Time.timeScale = 0;
    }
    //Unpauses the game
    void Unpause() {
        Time.timeScale = 1;
    }*/

}
