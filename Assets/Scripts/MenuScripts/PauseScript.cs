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

        if (SystemInfo.supportsAccelerometer) {
            if (Input.touchCount > 0) {
                foreach (Touch touch in Input.touches) {
                    if (touch.phase == TouchPhase.Began) {
                        if (Time.timeScale == 1) {
                            Time.timeScale = 0;
                            ShowPaused();
                        }
                    }
                }
            }
        }
        else if (Input.GetButtonDown("Cancel")) {
            if (Time.timeScale == 1) {
                Time.timeScale = 0;
                ShowPaused();
            }
        }
    }

    public void Reload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowPaused() {
        foreach (GameObject g in pauseObjects) {
            g.SetActive(true);
            AudioListener.volume = 0f;
        }
    }

    public void HidePaused() {
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
            AudioListener.volume = 1f;
        }
        if (SystemInfo.supportsAccelerometer) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Ended) {
                    foreach (GameObject g in pauseObjects) {
                        g.SetActive(false);
                    }
                }
            }
        }
        else {
            foreach (GameObject g in pauseObjects) {
                g.SetActive(false);
            }
        }
    }
}
