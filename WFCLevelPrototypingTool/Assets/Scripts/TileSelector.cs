using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    public void SelectNewTile(GameObject selectedTile)
    {
        for(int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).GetChild(4).GetComponentInChildren<TileButton>().ObjectToPlace = selectedTile;
        }
    }
}