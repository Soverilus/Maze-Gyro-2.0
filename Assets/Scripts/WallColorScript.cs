using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColorScript : MonoBehaviour {
    //this script changes wall colour based on how close it is to the ghost.

    //Use SpriteRenderer.color later on to change the wall's color
    SpriteRenderer wallSPR;

    //a reference to the ghost instantiation that's parsed in via FindGhost via the GhostAI script.
    GameObject ghostInst;

    [SerializeField]
    float distModifier;

    private void Start() {
        wallSPR = GetComponent<SpriteRenderer>();
    }

    public void FindGhost(GameObject ghost) {
        ghostInst = ghost;
    }

    void Update() {
        //can't change color if there is no ghost, so check if there's a ghost before continuing.
        if (ghostInst != null) {
            ColorOverDistance();
        }
        else {
            //otherwise, make the wall color Cyan (chose this color for the sci fi/computer aesthetic)
            wallSPR.color = Color.cyan;
        }
    }

    void ColorOverDistance() {
        if (Vector2.Distance(transform.position, ghostInst.transform.position) / distModifier < 0.5f) { //checks the Ghost's distance divided by a variable float and whether or not it's under half the distance.
            wallSPR.color = Color.Lerp(new Color(0.5f, 0f, 0f), Color.magenta, Vector2.Distance(transform.position, ghostInst.transform.position)/10f); //changes the wall's color based on that distance, from Magenta to a dark red.
        }

        else if (Vector2.Distance(transform.position, ghostInst.transform.position) / distModifier >= 0.5f) { //same as above,except it checks if it's over or equal to half the distance, and changes from cyan to Magenta.
            wallSPR.color = Color.Lerp(Color.magenta, Color.cyan, Vector2.Distance(transform.position, ghostInst.transform.position)/10f);
        }
    }
}
