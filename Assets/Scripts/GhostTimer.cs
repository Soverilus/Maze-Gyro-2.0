using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostTimer : MonoBehaviour {

    //check to see if we already spawned the ghost in order to disable it later
    bool spawnedGhost = false;

    //text reference to the timer
    Text timerText;

    //the gameobject Ghost
    [SerializeField]
    private GameObject ghostMachine;

    //transform location to spawn the ghost in
    [SerializeField]
    private Vector3 ghostSpawn;

    //reference to the prefab Ghost Machine enemy to spawn once timer runs out
    [SerializeField]
    //private GameObject ghostMachine;

    //the amount of time left
    private float timerTimeLeft;

    //the initial amount of time
    [SerializeField]
    private float initTime;

    void Start() {
        timerText = GetComponent<Text>();
        timerTimeLeft = initTime;
    }

    void Update() {
        Timer();
    }

    void Timer() {
        if (timerTimeLeft > 0f) {
            timerTimeLeft -= Time.deltaTime;
        }
        else {
            timerTimeLeft = 0f;
            SpawnGhost();
            Destroy(gameObject);
        }
        timerText.text = timerTimeLeft.ToString("F1");
    }

    void SpawnGhost() {
        if (!spawnedGhost) {
            Instantiate(ghostMachine, ghostSpawn, Quaternion.identity);
            Debug.Log("spawn ghost");
        }
        else {
            Debug.Log("ROLL TO THE EXIT!!1!!EXCLAMATIONPOINT");
        }
    }
}