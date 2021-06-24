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

    private Button tileButton;
    private bool occupied;

    private void Awake()
    {
        tileButton = GetComponent<Button>();
        occupied = false;
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
        }
    }
}