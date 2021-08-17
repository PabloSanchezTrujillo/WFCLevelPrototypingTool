using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    public bool GridInitialised { get; set; }

    [SerializeField] private int rows;
    [SerializeField] private int cols;
    [SerializeField] private float tileSize;
    [SerializeField] private GameObject tile;
    [SerializeField] private GameObject gridOptionsMenu;
    [SerializeField] private Text inputRows;
    [SerializeField] private Text inputCols;

    private Backtracking backtracking;
    private List<Tile> gridTile;
    private List<int> gridIndexes;
    private List<int[]> gridConnections;

    private void Awake()
    {
        backtracking = GetComponent<Backtracking>();
        gridTile = new List<Tile>();
        gridIndexes = new List<int>();
        gridConnections = new List<int[]>();

        GridInitialised = false;
    }

    public void GenerateButton()
    {
        try {
            rows = int.Parse(inputRows.text);
            cols = int.Parse(inputCols.text);

            if(rows <= 0) {
                rows = 6;
            }
            if(cols <= 0) {
                cols = 6;
            }
        }
        catch {
            print("Invalid input");
        }
        gridOptionsMenu.SetActive(false);

        GenerateGrid();
    }

    public void GenerateGrid()
    {
        int id = 0;

        for(int row = 0; row < rows; row++) {
            for(int col = 0; col < cols; col++) {
                GameObject tileObject = Instantiate(tile, transform);

                float posX = col * tileSize;
                float posZ = row * -tileSize;

                tileObject.transform.position = new Vector3(posX, 0, posZ);
                InitTile(tileObject, id, row, col);

                id++;
            }
        }

        float gridWidth = cols * tileSize;
        float gridHeight = rows * tileSize;
        transform.position = new Vector3(-gridWidth / 2 + tileSize / 2, 0, gridHeight / 2 - tileSize / 2);

        InitGrid();

        GridInitialised = true;
    }

    private void InitGrid()
    {
        for(int i = 0; i < transform.childCount; i++) {
            Tile childTile = transform.GetChild(i).GetComponent<Tile>();

            gridTile.Add(childTile);
            gridIndexes.Add(childTile.TileId);
            gridConnections.Add(childTile.Neighbours);
        }
    }

    private void InitTile(GameObject tileObject, int id, int row, int col)
    {
        Tile tile = tileObject.GetComponent<Tile>();

        // Tile Id
        tile.TileId = id;
        tile.Row = row;
        tile.Col = col;

        // Tile neighbours
        // Tile neighbours order: [Top, Left, Right, Bottom]
        if(row == 0 && col == 0) {
            tile.Neighbours = new int[] { -1, -1, id + 1, id + cols };
        }
        else if(row == 0 && col == cols - 1) {
            tile.Neighbours = new int[] { -1, id - 1, -1, id + cols };
        }
        else if(row == rows - 1 && col == 0) {
            tile.Neighbours = new int[] { id - cols, -1, id + 1, -1 };
        }
        else if(row == rows - 1 && col == cols - 1) {
            tile.Neighbours = new int[] { id - cols, id - 1, -1, -1 };
        }
        else if(row == 0) {
            tile.Neighbours = new int[] { -1, id - 1, id + 1, id + cols };
        }
        else if(row == rows - 1) {
            tile.Neighbours = new int[] { id - cols, id - 1, id + 1, -1 };
        }
        else if(col == 0) {
            tile.Neighbours = new int[] { id - cols, -1, id + 1, id + cols };
        }
        else if(col == cols - 1) {
            tile.Neighbours = new int[] { id - cols, id - 1, -1, id + cols };
        }
        else {
            tile.Neighbours = new int[] { id - cols, id - 1, id + 1, id + cols };
        }
    }

    public void BacktrackGrid(int start)
    {
        backtracking.BacktrackGrid(gridTile, new List<int>(), start);
    }

    public void LocalBacktrackingGrid(int start)
    {
        backtracking.LocalBacktrackingGrid(gridTile, new List<int>(), start);
    }

    public int GetRows()
    {
        return rows;
    }

    public int GetCols()
    {
        return cols;
    }

    public void SetRowsAndCols(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
    }

    public List<Tile> GetChildTiles()
    {
        List<Tile> tilesList = new List<Tile>();

        for(int i = 0; i < gameObject.transform.childCount; i++) {
            tilesList.Add(gameObject.transform.GetChild(i).GetComponent<Tile>());
        }

        return tilesList;
    }
}