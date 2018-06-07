using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenScript : MonoBehaviour {
    public Texture2D mapSpawnImage;
    public GameObject wallObj;
    public GameObject trapObj;
    public GameObject enemyObj;
    public GameObject winObj;
    GameObject playerObj;

    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        GenerateMap();
    }

    void Update() {

    }

    void GenerateMap() {
        GameObject tempWall = Instantiate(wallObj, Vector3.zero, Quaternion.identity);
        Vector2 wallSize = tempWall.GetComponent<Collider2D>().bounds.size;
        Debug.Log(wallSize);
        for (int w = 0; w < mapSpawnImage.width; w++) {
            for (int h = 0; h < mapSpawnImage.height; h++) {
                Vector3 placementPos = new Vector3(w * wallSize.x, h * wallSize.y - mapSpawnImage.height, 0);
                if (mapSpawnImage.GetPixel(w, h) == Color.black) {
                    PlaceObject(placementPos, wallObj);
                }
                else if (mapSpawnImage.GetPixel(w, h) == Color.red) {
                    PlaceObject(placementPos, trapObj);
                }
                else if (mapSpawnImage.GetPixel(w, h) == Color.magenta) {
                    //PlaceObject(placementPos, enemyObj);
                }
                else if (mapSpawnImage.GetPixel(w, h) == Color.green) {
                    //PlaceObject(placementPos, winObj);
                }
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
