using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBaseValue : IValue<Tile>
{
    public Tile Value => throw new System.NotImplementedException();

    public bool Equals(IValue<Tile> x, IValue<Tile> y)
    {
        throw new System.NotImplementedException();
    }

    public bool Equals(IValue<Tile> other)
    {
        throw new System.NotImplementedException();
    }

    public int GetHashCode(IValue<Tile> obj)
    {
        throw new System.NotImplementedException();
    }
}