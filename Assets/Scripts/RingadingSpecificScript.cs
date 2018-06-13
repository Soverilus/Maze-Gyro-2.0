using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingadingSpecificScript : MonoBehaviour {
    AudioSource mySource;

    public float timeMult;

    void Start() {
        mySource = GetComponent<AudioSource>();
        mySource.volume = 0;

    }

    void Update() {
        if (mySource.volume != 1f) {
            mySource.volume += Time.deltaTime * timeMult;
        }
        //if (Input.GetKey(KeyCode.A)) {
        //    mySource.time = mySource.clip.length - 1f;
        //}
        if (mySource.time >= mySource.clip.length - 0.5f) {
            mySource.time = 50;
        }
    }
}
