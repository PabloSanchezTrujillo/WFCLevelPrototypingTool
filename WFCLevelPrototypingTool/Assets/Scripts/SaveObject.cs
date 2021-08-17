using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveObject
{
    public int Rows;
    public int Cols;
    public TileData[] Tiles;
}

[System.Serializable]
public class TileData
{
    public int TileId;
    public int ObjectIndex;
}