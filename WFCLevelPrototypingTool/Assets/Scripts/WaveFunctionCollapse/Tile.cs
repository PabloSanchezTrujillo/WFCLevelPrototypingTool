using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [field: SerializeField] public int TileId { get; set; }
    [field: SerializeField] public int ObjectIndex { get; set; }

    // Tile neighbours order: [Top, Left, Right, Bottom]
    [field: SerializeField] public int[] Neighbours { get; set; }

    [SerializeField] private TileButton tileButton;

    private void Awake()
    {
        ObjectIndex = 0;
    }

    public void SelectNewTile(GameObject selectedTile)
    {
        tileButton.ObjectToPlace = selectedTile;
    }

    public void ChangeObject()
    {
        print(transform.GetChild(5).name);
        Destroy(transform.GetChild(5).gameObject);
    }
}