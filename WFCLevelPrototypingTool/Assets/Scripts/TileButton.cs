using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    [SerializeField] private GameObject objectToPlace;
    [SerializeField] private Color unoccupiedTile;
    [SerializeField] private Color occupiedTile;

    private Tile parentTile;
    private Button tileButton;
    private bool occupied;

    private void Awake()
    {
        tileButton = GetComponent<Button>();
        occupied = false;
    }

    private void Start()
    {
        parentTile = transform.parent.GetComponentInParent<Tile>();
    }

    public void BuildOnTile()
    {
        if(!occupied) {
            GameObject objectPlaced = Instantiate(objectToPlace, tile.transform, false);
            objectPlaced.transform.localPosition = Vector3.zero;

            occupied = true;

            ColorBlock buttonColors = tileButton.colors;
            buttonColors.highlightedColor = occupiedTile;
            tileButton.colors = buttonColors;

            parentTile.ObjectIndex = 1;

            transform.parent.parent.GetComponentInParent<GridGenerator>().BacktrackGrid(parentTile.TileId);
        }
    }
}