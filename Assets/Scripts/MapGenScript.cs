using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenScript : MonoBehaviour {
    //uses an image to spawn prefab walls and objects. easy map making.
    public Texture2D mapSpawnImage;

    //reference to the various objects to spawn in GenerateMap(), as well as a reference to the player to move once the map spawns.
    public GameObject wallObj;
    public GameObject trapObj;
    public GameObject winObj;
    public GameObject backgroundObj;
    public GameObject scoreObj;
    GameObject playerObj;

    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        GenerateMap();
    }

    void Update() {

    }

    void GenerateMap() {
        //generates a temporary wall object to calculate wallSize from. destroys temporary wall at the end of GenerateMap().
        GameObject tempWall = Instantiate(wallObj, Vector3.zero, Quaternion.identity);
        Vector2 wallSize = tempWall.GetComponent<Collider2D>().bounds.size;
        //Debug.Log(wallSize);
        for (int w = 0; w < mapSpawnImage.width; w++) {
            for (int h = 0; h < mapSpawnImage.height; h++) {
                Vector3 placementPos = new Vector3(w * wallSize.x, h * wallSize.y - mapSpawnImage.height, 0);

                //the various placement scripts for objects generated via the spawnImage:
                if (w == mapSpawnImage.width / 2 && h == mapSpawnImage.height / 2) {
                    //PlaceObject(placementPos, backgroundObj);
                }
                if (mapSpawnImage.GetPixel(w, h) == Color.black) {
                    PlaceObject(placementPos, wallObj);
                }
                else if (mapSpawnImage.GetPixel(w, h) == Color.red) {
                    PlaceObject(placementPos, trapObj);
                }
                else if (mapSpawnImage.GetPixel(w, h) == Color.magenta) {
                    PlaceObject(placementPos, scoreObj);
                }
                else if (mapSpawnImage.GetPixel(w, h) == Color.green) {
                    //PlaceObject(placementPos, winObj);
                }
                //move the player to this pixel. only one can exist atm.
                else if (mapSpawnImage.GetPixel(w, h) == Color.blue) {
                    playerObj.transform.position = placementPos;
                }
            }
        }
        Destroy(tempWall);
    }

    void PlaceObject(Vector3 pos, GameObject obj) {
        Instantiate(obj, pos, Quaternion.identity);
    }
}
