using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : IInputReader<Tile>
{
    public IValue<Tile>[][] ReadInputToGrid()
    {
        var grid = ReadInputToGrid();
        TileBaseValue[][] gridOfValues = null;

        if(grid != null) {
            gridOfValues = CollectionExtension.CreateJaggedArray<TileBaseValue[][]>(grid.Length, grid[0].Length);
            for(int row = 0; row < grid.Length; row++) {
                for(int col = 0; col < grid[0].Length; col++) {
                    //gridOfValues[row][col] = new TileBaseValue(grid[row][col]);
                }
            }
        }

        return gridOfValues;
    }
}