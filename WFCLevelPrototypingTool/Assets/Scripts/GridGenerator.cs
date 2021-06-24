using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private int rows;
    [SerializeField] private int cols;
    [SerializeField] private float tileSize;
    [SerializeField] private GameObject tile;

    // Start is called before the first frame update
    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for(int row = 0; row < rows; row++) {
            for(int col = 0; col < cols; col++) {
                GameObject tileObject = Instantiate(tile, transform);

                float posX = col * tileSize;
                float posZ = row * -tileSize;

                tileObject.transform.position = new Vector3(posX, 0, posZ);
            }
        }

        float gridWidth = cols * tileSize;
        float gridHeight = rows * tileSize;
        transform.position = new Vector3(-gridWidth / 2 + tileSize / 2, 0, gridHeight / 2 - tileSize / 2);
    }
}