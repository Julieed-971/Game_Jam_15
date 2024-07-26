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
        grid = new Cell[width * height];
        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++){
                float x_value = y%2 == 0 ? x : x + 0.5f;
                GameObject tile = Instantiate(groundTilePrefab, new Vector3(x_value, ((float)y)/4, 0), Quaternion.identity);
                tile.transform.SetParent(transform);
                tile.GetComponent<Cell>().coordinates = new Vector2Int(x, y);
                // tile.GetComponent<Cell>().lightLevel = Random.Range(-5, 6);
                tile.GetComponent<Cell>().UpdateColor();
                tile.GetComponent<Cell>().groundGrid = this;
                grid[x + y * width] = tile.GetComponent<Cell>();
            }
        }
    }

    public void HighlightCells(Vector2Int startCoordinates, int width, int height){
        bool validPlacement = true;
        int x = startCoordinates.x;
        int y = startCoordinates.y;
        int newX = 0;
        int newY = 0;
        if (y % 2 == 0) {            
            for (int j = 0; j< height; j++){
                int startX = x-((j+1)/2);
                int startY = y + j;
                for (int i = 0; i<width; i++){
                    if (j %2 == 0){
                        newX = startX  + i/2;
                        newY = startY + i;
                    } else {
                        newX = startX + (i+1)/2;
                        newY = startY + i;
                    }
                    if (HighlightThatCell(newX, newY) == false){
                        validPlacement = false;
                    }
                }
            }
        } else {
            for (int j = 0; j< height; j++){
                int startX = x-(j/2);
                int startY = y + j;
                for (int i = 0; i<width; i++){
                    if (j %2 == 0){
                        newX = startX  + (i+1)/2;
                        newY = startY + i;
                    } else {
                        newX = startX + i/2;
                        newY = startY + i;
                    }
                    if (HighlightThatCell(newX, newY) == false){
                        validPlacement = false;
                    }
                }
            }
        }

        Debug.Log("Highlighting cells around " + startCoordinates + " with width " + width + " and height " + height);

        if (validPlacement){
            Debug.Log("Valid placement");
        } else {
            Debug.Log("Invalid placement");
        }
    }
    public bool HighlightThatCell(int x, int y){
        if (x >= 0 && x < this.width && y >= 0 && y < this.height){
            if (!grid[x + y * this.width].HighlightCell()){
                return false;
            } else {
                return true;
            }
        } else {
            return false;                
        }
    }
    // Function to clear a radius of 5 around current cell leaved
    public void ClearColors(Vector2Int startCoordinates){
        int w = 10;
        int h = 10;
        for (int x = startCoordinates.x-4; x < startCoordinates.x + w; x++){
            for (int y = startCoordinates.y-4; y < startCoordinates.y + h; y++){
                if (x >= 0 && x < this.width && y >= 0 && y < this.height){
                    grid[x + y * this.width].ClearCell();
                }
            }
        }
    }
}
