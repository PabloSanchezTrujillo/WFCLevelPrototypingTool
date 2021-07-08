using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [field: SerializeField] public int TileId { get; set; }
    [field: SerializeField] public int ObjectIndex { get; set; }
    [field: SerializeField] public int[] Neighbours { get; set; }

    private void Awake()
    {
        ObjectIndex = 0;
    }
}