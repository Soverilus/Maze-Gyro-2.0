using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MovementScript : MonoBehaviour {
    AudioSource ballAudio;
    Rigidbody2D playerRB;
    public float maxVel;
    Vector2 moveInput;
    //Vector2 moveInputRaw;
    public float velMult;
    public float sensitivity;

    void Start() {
        playerRB = GetComponent<Rigidbody2D>();
        ballAudio = GetComponent<AudioSource>();
    }

    void Update() {

    }

    private void FixedUpdate() {
        PlayerMove();
        ChangePitch();
    }

    private void PlayerMove() {
        //moves the player based on tilt of android, or, if no accelerometer exists, uses keyboard or controller controls. multiplies movement and clamps to a maximum.
        //moveInputRaw = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (SystemInfo.supportsAccelerometer) {
            moveInput = new Vector2(Mathf.Clamp(Input.acceleration.x * sensitivity, -1.25f, 1.25f), Mathf.Clamp(Input.acceleration.y * sensitivity, -1.25f, 1.25f));
        }
        else {
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        playerRB.AddForce(moveInput * velMult);
        if (playerRB.velocity.magnitude > maxVel) {
            playerRB.AddForce(playerRB.velocity.normalized * -velMult);
        }
    }
    void ChangePitch() {
        ballAudio.volume = (maxVel + playerRB.velocity.magnitude) / maxVel - 1f;
        ballAudio.pitch = (maxVel + playerRB.velocity.magnitude) / maxVel - 1f;
        //Debug.Log((maxVel + playerRB.velocity.magnitude) / maxVel);
    }
}
