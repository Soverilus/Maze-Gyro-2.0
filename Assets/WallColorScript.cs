using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColorScript : MonoBehaviour {
    public float test;
    SpriteRenderer wallSPR;
    GameObject ghostInst;

    private void Start() {
        wallSPR = GetComponent<SpriteRenderer>();
    }

    public void FindGhost(GameObject ghost) {
        ghostInst = ghost;
    }

    void Update() {
        if (ghostInst != null) {
            ColorOverDistance();
        }
        else {
            wallSPR.color = Color.cyan;
        }
    }

    void ColorOverDistance() {
        if (Vector2.Distance(transform.position, ghostInst.transform.position) / 10f < 0.5f) {
            wallSPR.color = Color.Lerp(new Color(0.5f, 0f, 0f), Color.magenta, Vector2.Distance(transform.position, ghostInst.transform.position)/10f);
        }
        else if (Vector2.Distance(transform.position, ghostInst.transform.position) / 10f >= 0.5f) {
            wallSPR.color = Color.Lerp(Color.magenta, Color.cyan, Vector2.Distance(transform.position, ghostInst.transform.position)/10f);
        }
    }
}
