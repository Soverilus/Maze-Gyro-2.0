using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour {
    //a reference to every wall in the scene
    GameObject[] walls;

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
        FindWalls();
        target = GameObject.FindGameObjectWithTag("Player");
        ghostRB = GetComponent<Rigidbody2D>();
    }

    void FindWalls() {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        for (int i = 0; i < walls.Length; i++) {
            walls[i].GetComponent<WallColorScript>().FindGhost(gameObject);
        }
    }

    private void FixedUpdate() {
        GhostMove();
    }

    private void GhostMove() {
        ghostMove = new Vector2(- transform.position.x + target.transform.position.x, - transform.position.y + target.transform.position.y).normalized;
        ghostRB.AddForce(ghostMove * velMult);
        if (ghostRB.velocity.magnitude > maxVel) {
            ghostRB.AddForce(ghostRB.velocity.normalized * -velMult);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == ("Destructible")|| collision.gameObject.tag == ("Wall")) {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == ("Player")) {
            //function to end game in defeat
        }
    }
}