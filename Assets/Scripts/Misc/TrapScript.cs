using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour {
    CircleCollider2D myCol;

    private void Start() {
        myCol = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == ("Player")) {
            Rigidbody2D myRB = collision.GetComponent<Rigidbody2D>();
            MovementScript tarMov = collision.GetComponent<MovementScript>();
            PlayerHealth tarHP = collision.GetComponent<PlayerHealth>();
            Vector2 tarVel = myRB.velocity.normalized;
            myRB.AddForce(-2 * Mathf.Abs(myCol.radius - Vector2.SqrMagnitude(transform.position - collision.transform.position)) * tarVel * tarMov.velMult / 1.5f);
            tarHP.LoseHealth(1f);
        }
    }
}
