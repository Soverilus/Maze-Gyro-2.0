using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeOut : MonoBehaviour {

    bool fadeNow = false;
    AudioSource mySource;

    private void Start() {
        mySource = GetComponent<AudioSource>();
    }

    public void FadeOut() {
        fadeNow = true;
    }

    private void Update() {
        if (fadeNow) {
            FadeNow();
        }
    }

    void FadeNow() {
        mySource.volume -= Time.deltaTime * 0.5f;
        if (mySource.volume <= 0.01f) {
            mySource.enabled = false;
        }
    }
}
