using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DataCubePickup : MonoBehaviour {
    //reference to the score text instance and script
    ScoreDisplay scoreInstance;

    //how much score to add to scoreInstance.
    int scoreAdd;

    //the score multiplier (RECOMMENDED: above 10)
    [SerializeField]
    int scoreMult;

    GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreInstance = GameObject.FindGameObjectWithTag("ScoreDisplay").GetComponent<ScoreDisplay>();
        SetScore();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject == player) {
            AddScore();
        }
    }

    void AddScore() {
        scoreInstance.ScoreUpdate(scoreAdd);
        Destroy(gameObject);
    }

    void SetScore() {
        //makes the score equal to an int multiplied by the magnitude of the distance to the player
        scoreAdd = 75*Mathf.RoundToInt(Vector2.Distance(transform.position, player.transform.position));
    }
}