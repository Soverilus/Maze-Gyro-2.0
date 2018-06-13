using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayPickupSound : MonoBehaviour {

    [SerializeField]
    private AudioSource pickupSource;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Pickup") {
            pickupSource.time = 0;
            pickupSource.Play();
        }
    }
}
