using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class BallAnimation : MonoBehaviour {
    //number to divide the magnitude of the ball by to set the animation speed
    [SerializeField]
    private float animSpeedDiv;

    Animator myAnim;

    Rigidbody2D playerParentRB;

    //for use in getting the angle between this object and the velocity of the referenced Rigidbody2D
    float angle;

    void Start() {
        //references to the player's Rigidbody2D and this object's Animator components
        myAnim = GetComponent<Animator>();
        playerParentRB = GetComponentInParent<Rigidbody2D>();
    }

    void Update() {
        //code for animation speed and direction
        AnimationSpeed();
        DirecitonCalc();
    }

    void DirecitonCalc() {
        //calculate tangent of the velocity's direction - turn it into degrees for use in AngleAxis, which rotates degrees around an axis (forwards, or z axis)
        //in order to turn this object towards the player's direction, thus turning the animation (as the object this is attached to is the Animator GameObject as a child of the player.
        angle = Mathf.Atan2(playerParentRB.velocity.y, playerParentRB.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
    }

    void AnimationSpeed() {
        //uses the magnitude of the ball's velocity to determine animation speed and divides it by a number
        myAnim.speed = playerParentRB.velocity.magnitude / animSpeedDiv;
    }
}
