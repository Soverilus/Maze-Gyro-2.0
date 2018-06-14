using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public WinLoseScript lose;
    [SerializeField]
    float maxHealth;
    public float playerHealth;

    private void Start() {
        playerHealth = maxHealth;
    }

    void Update() {
        if (playerHealth <= 0) {
            lose.Lose();
        }
    }
    public void LoseHealth(float damage) {
        playerHealth -= damage;
    }
}
