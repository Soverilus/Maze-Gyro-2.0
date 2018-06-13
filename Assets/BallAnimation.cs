using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class BallAnimation : MonoBehaviour {
    Animator myAnim;
    Rigidbody2D playerParentRB;
    float angle;

    void Start() {
        myAnim = GetComponent<Animator>();
        playerParentRB = GetComponentInParent<Rigidbody2D>();
    }

    void Update () {
        //code for animation speed and direction vvv
        AnimationSpeed();
        DirecitonCalc();
	}

    void DirecitonCalc() {
        //calculate tangent of the velocity's direction - turn it into degrees for use in AngleAxis, which rotates degrees around an axi (forwards, or z axis)
        angle = Mathf.Atan2(playerParentRB.velocity.y, playerParentRB.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
    }
    
    void AnimationSpeed() {
        //uses magnitude of velocity 
        myAnim.speed = playerParentRB.velocity.magnitude / 3;
    }
}
