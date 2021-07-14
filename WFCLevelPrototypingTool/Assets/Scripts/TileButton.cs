using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{
    [field: SerializeField] public GameObject ObjectToPlace { get; set; }

    [SerializeField] private GameObject tile;
    [SerializeField] private Color unoccupiedTile;
    [SerializeField] private Color occupiedTile;

    private Tile parentTile;
    private Button tileButton;

    private void Awake()
    {
        tileButton = GetComponent<Button>();
    }

    private void Start()
    {
        parentTile = transform.parent.GetComponentInParent<Tile>();
    }

    public void BuildOnTile()
    {
        if(!parentTile.Occupied) {
            // Instantiate the new object
            GameObject objectPlaced = Instantiate(ObjectToPlace, tile.transform, false);
            objectPlaced.transform.localPosition = Vector3.zero;

            // Mark the tile as occupied
            parentTile.Occupied = true;

            // Change the tile button's color
            ColorBlock buttonColors = tileButton.colors;
            buttonColors.highlightedColor = occupiedTile;
            tileButton.colors = buttonColors;

            // Change the tile's index to the new object index
            BuildingObject buildingObject = ObjectToPlace.GetComponent<BuildingObject>();
            parentTile.ObjectIndex = buildingObject.ObjectIndex;

            // Backtrack the grid
            transform.parent.parent.GetComponentInParent<GridGenerator>().BacktrackGrid(parentTile.TileId, parentTile.ObjectIndex);
        }
    }

    public void BuildOnTile(GameObject objectToBuild)
    {
        if(!parentTile.Occupied) {
            // Instantiate the new object
            GameObject objectPlaced = Instantiate(objectToBuild, tile.transform, false);
            objectPlaced.transform.localPosition = Vector3.zero;

            // Mark the tile as occupied
            parentTile.Occupied = true;

            // Change the tile button's color
            ColorBlock buttonColors = tileButton.colors;
            buttonColors.highlightedColor = occupiedTile;
            tileButton.colors = buttonColors;

            // Change the tile's index to the new object index
            BuildingObject buildingObject = objectToBuild.GetComponent<BuildingObject>();
            parentTile.ObjectIndex = buildingObject.ObjectIndex;

            transform.parent.parent.GetComponentInParent<GridGenerator>().BacktrackGrid(parentTile.TileId, parentTile.ObjectIndex);
        }
    }

    public void ChangeButtonColor()
    {
        ColorBlock buttonColors = tileButton.colors;
        buttonColors.highlightedColor = unoccupiedTile;
        tileButton.colors = buttonColors;
    }
}