using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenScript : MonoBehaviour {
    public Texture2D mapSpawnImage;
    public GameObject wallObject;
    public GameObject trapObject;

    void Start() {
        GenerateMap();
    }

    void Update() {

    }

    void GenerateMap() {
        GameObject tempWall = Instantiate(wallObject, Vector3.zero, Quaternion.identity);
        Vector2 wallSize = tempWall.GetComponent<Collider2D>().bounds.size;
        Debug.Log(wallSize);
        for (int w = 0; w < mapSpawnImage.width; w++) {
            for (int h = 0; h < mapSpawnImage.height; h++) {
                Vector3 placementPos = new Vector3(w * wallSize.x, h * wallSize.y - mapSpawnImage.height, 0);
                if (mapSpawnImage.GetPixel(w, h) == Color.black) {
                    PlaceWall(placementPos);
                }
                if (mapSpawnImage.GetPixel(w, h) == Color.red) {
                    PlaceTrap(placementPos);
                }
            }
        }
        Destroy(tempWall);
    }

    void PlaceWall(Vector3 pos) {
        Instantiate(wallObject, pos, Quaternion.identity);
    }

    void PlaceTrap(Vector3 pos) {
        Instantiate(trapObject, pos, Quaternion.identity);
    }
}
