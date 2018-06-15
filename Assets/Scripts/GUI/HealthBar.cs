using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    PlayerHealth hP;
    Slider slide;
    void Start() {
        hP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        slide = GetComponent<Slider>();
    }

    void Update() {
        slide.value = hP.playerHealth;
    }
}
