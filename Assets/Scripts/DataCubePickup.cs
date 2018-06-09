using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DataCubePickup : MonoBehaviour {

    ScoreDisplay scoreInstance;
    int scoreAdd;
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
        scoreAdd = 75*Mathf.RoundToInt(Vector2.Distance(transform.position, player.transform.position));
    }
}