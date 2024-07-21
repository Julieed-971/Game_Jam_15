using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class GroundGridGenerator : MonoBehaviour {
    public GameObject groundTilePrefab;
    public int width;
    public int height;

    public Cell[] grid;

    // Start is called before the first frame update
    void Start() {
        GenerateGroundTiles();
    }
    // Generate isometric tilemap
    void GenerateGroundTiles(){
        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++){
                float x_value = y%2 == 0 ? x : x + 0.5f;
                GameObject tile = Instantiate(groundTilePrefab, new Vector3(x_value, ((float)y)/4, 0), Quaternion.identity);
                tile.transform.SetParent(transform);
                tile.GetComponent<Cell>().coordinates = new Vector2Int(x, y);
                // tile.GetComponent<Cell>().lightLevel = Random.Range(-5, 6);
                tile.GetComponent<Cell>().UpdateColor();
            }
        }
    }
}
