using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour {

    public float ghostDamage;
    //editor use for ghost check radius and color change percentile
    public float checkDist;

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

        //finds the player to make it the ghost's target
        target = GameObject.FindGameObjectWithTag("Player");
        ghostRB = GetComponent<Rigidbody2D>();
    }

    void FindWalls() { //finds all of the walls and activates their FindGhost function to parse itself to them.
                       // walls = GameObject.FindGameObjectsWithTag("Wall");
        Collider2D[] myObjects = Physics2D.OverlapCircleAll(transform.position, checkDist);

        for (int i = 0; i < myObjects.Length; i++) {
            if (myObjects[i].tag == "Wall") {
                SpriteRenderer wallSPR = myObjects[i].GetComponent<SpriteRenderer>();
                float dist = Vector2.Distance(myObjects[i].transform.position, transform.position) / checkDist;

                if (dist < 0.5f) { //checks the Ghost's distance divided by a variable float and whether or not it's under half the distance.
                    wallSPR.color = Color.Lerp(new Color(0.5f, 0f, 0f), Color.magenta, dist); //changes the wall's color based on that distance, from Magenta to a dark red.
                }
                else if (dist >= 0.5f) { //same as above,except it checks if it's over or equal to half the distance, and changes from cyan to Magenta.
                    wallSPR.color = Color.Lerp(Color.magenta, Color.cyan, dist);
                }
            }
        }
    }

    private void FixedUpdate() {
        GhostMove();
        FindWalls();
    }

    private void GhostMove() { //uses the same physics as MovementScript to move the Ghost, albeit with it's input always being the direction to the ball (to a total magnitude of 1)
        ghostMove = new Vector2(-transform.position.x + target.transform.position.x, -transform.position.y + target.transform.position.y).normalized;
        ghostRB.AddForce(ghostMove * velMult);
        if (ghostRB.velocity.magnitude > maxVel) {
            ghostRB.AddForce(ghostRB.velocity.normalized * -velMult);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        //if something is either Destructible or a Wall, simply destroy it.
        if (collision.gameObject.tag == ("Destructible") || collision.gameObject.tag == ("Wall") || collision.gameObject.tag == ("Pickup")) {
            Destroy(collision.gameObject);
        }

        //ends the game in Defeat, quarter score.
        if (collision.gameObject.tag == ("Player")) {
            collision.gameObject.GetComponent<PlayerHealth>().LoseHealth(ghostDamage * Time.deltaTime);
        }
    }
}