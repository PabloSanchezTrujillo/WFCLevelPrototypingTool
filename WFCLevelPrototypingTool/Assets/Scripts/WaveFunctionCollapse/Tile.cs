using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [field: SerializeField] public int TileId { get; set; }
    [field: SerializeField] public int ObjectIndex { get; set; }

    // Tile neighbours order: [Top, Left, Right, Bottom]
    [field: SerializeField] public int[] Neighbours { get; set; }

    public bool Occupied { get; set; }

    [SerializeField] private TileButton tileButton;

    private List<GameObject> tilesList;

    private void Awake()
    {
        tilesList = GetComponent<TilesList>().tilesList;

        ObjectIndex = 0;
        Occupied = false;
    }

    public void SelectNewTile(GameObject selectedTile)
    {
        tileButton.ObjectToPlace = selectedTile;
    }

    // TODO: El objeto tiene que cambiar ANTES de continuar con el backtracking
    public void ChangeObject(int objectIndex)
    {
        //print(transform.GetChild(5).name);
        Occupied = false;
        Destroy(transform.GetChild(5).gameObject);
        tileButton.BuildOnTile(tilesList[objectIndex]);
        //tileButton.ChangeButtonColor();
    }
}