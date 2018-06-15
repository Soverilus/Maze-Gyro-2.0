using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public GameObject targetObject;
    Vector3 targetPos;

    void Update() {
        CamFollow();
    }

    private void CamFollow() {
        //makes the camera's position the player's
        targetPos = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, -10);
        transform.position = targetPos;
    }
}
