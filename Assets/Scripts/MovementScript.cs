using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MovementScript : MonoBehaviour {
    Rigidbody2D playerRB;
    public float maxVel;
    Vector2 moveInput;
    //Vector2 moveInputRaw;
    public float velMult;
    public float sensitivity;

	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

	}

    private void FixedUpdate() {
        //moveInputRaw = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (SystemInfo.supportsAccelerometer) {
            moveInput = new Vector2(Mathf.Clamp(Input.acceleration.x*sensitivity,-1, 1), Mathf.Clamp(Input.acceleration.y*sensitivity, -1, 1));
        } else {
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
            playerRB.AddForce(moveInput * velMult);
        if (playerRB.velocity.magnitude > maxVel) {
            playerRB.AddForce(playerRB.velocity.normalized *- velMult);
        }
    }
}
