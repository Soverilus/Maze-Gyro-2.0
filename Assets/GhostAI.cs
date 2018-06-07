using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour {
    //velocity multiplier for the ghost's acceleration
    [SerializeField]
    private float velMult;

    //maximum velocity for the ghost
    [SerializeField]
    private float maxVel;

    //the direction of the ghost's movement
    private Vector2 ghostMove;

    //the ghost's rigidbody
    private Rigidbody2D ghostRB;

    //the current target of the ghost;
    private GameObject target;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate() {
        GhostMove();
    }

    private void GhostMove() {
        ghostMove = new Vector2(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y).normalized;
        ghostRB.AddForce(ghostMove);
        if (ghostRB.velocity.magnitude > maxVel * velMult) {
            ghostRB.AddForce(ghostRB.velocity.normalized * -velMult);
        }
    }
}

