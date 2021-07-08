using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objects
{
    public ObjectPlaced[] ObjectPlaced;
}

[System.Serializable]
public class ObjectPlaced
{
    public int Index;
    public string Name;
    public Neighbours Neighbours;
    public Replacement[] Replacements;
}

[System.Serializable]
public class Neighbours
{
    public int[] TopNeighbours;
    public int[] LeftNeighbours;
    public int[] RightNeighbours;
    public int[] BottomNeighbours;
}

[System.Serializable]
public class Replacement
{
    public int Index;
    public string Name;
    public Neighbours Neighbours;
}