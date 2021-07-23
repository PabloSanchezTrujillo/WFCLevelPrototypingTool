using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backtracking : MonoBehaviour
{
    private Objects jsonObject;

    private void Awake()
    {
        jsonObject = GetComponent<JSONReader>().ReadJSON();
    }

    public void BacktrackGrid(List<Tile> grid, List<int> visited, int tileId)
    {
        Queue<int> queue = new Queue<int>();
        string path = "Path: ";

        queue.Enqueue(tileId);
        visited.Add(tileId);

        while(queue.Count != 0) {
            int tile = queue.Peek();
            queue.Dequeue();

            if(tile != -1) {
                path += grid[tile].TileId + " - ";
                WaveFunctionCollapse(grid, grid[tile]);

                foreach(int neighbour in grid[tile].Neighbours) {
                    if(!visited.Contains(neighbour)) {
                        queue.Enqueue(neighbour);
                        visited.Add(neighbour);
                    }
                }
            }
        }
        path += "[ " + visited.Count.ToString() + " ]";

        //print(path);
    }

    public void LocalBacktrackingGrid(List<Tile> grid, List<int> visited, int tileId)
    {
        Queue<int> queue = new Queue<int>();
        print("Local Backtracking Grid");

        // Add the actual tile
        queue.Enqueue(tileId);
        visited.Add(tileId);

        // Add the tile's neighbours
        foreach(int neighbour in grid[tileId].Neighbours) {
            queue.Enqueue(neighbour);
            visited.Add(neighbour);
        }

        while(queue.Count != 0) {
            int tile = queue.Peek();
            queue.Dequeue();

            WaveFunctionCollapse(grid, grid[tile]);
        }
    }

    private void WaveFunctionCollapse(List<Tile> grid, Tile clickedTile) // Tile neighbours order: [Top, Left, Right, Bottom]
    {
        // Ignore empty tiles
        if(clickedTile.ObjectIndex == 0) {
            return;
        }

        List<int> neighboursObjectsIndexes = new List<int>();
        bool validObject = true; // Send an error if there is NO valid object to place

        // Check TOP neighbours
        // Neighbours' values in JSON file
        foreach(int n in jsonObject.ObjectPlaced[clickedTile.ObjectIndex].Neighbours.TopNeighbours) {
            neighboursObjectsIndexes.Add(n);
        }

        // Neighbours' values in the grid
        if(clickedTile.Neighbours[0] == -1) {
            if(!neighboursObjectsIndexes.Contains(0)) {
                validObject = false;
            }
        }
        else {
            if(!neighboursObjectsIndexes.Contains(grid[clickedTile.Neighbours[0]].ObjectIndex)) {
                validObject = false;
            }
        }

        neighboursObjectsIndexes.Clear();

        // Check LEFT neighbours
        // Neighbours' values in JSON file
        foreach(int n in jsonObject.ObjectPlaced[clickedTile.ObjectIndex].Neighbours.LeftNeighbours) {
            neighboursObjectsIndexes.Add(n);
        }

        // Neighbours' values in the grid
        if(clickedTile.Neighbours[1] == -1) {
            if(!neighboursObjectsIndexes.Contains(0)) {
                validObject = false;
            }
        }
        else {
            if(!neighboursObjectsIndexes.Contains(grid[clickedTile.Neighbours[1]].ObjectIndex)) {
                validObject = false;
            }
        }

        neighboursObjectsIndexes.Clear();

        // Check RIGHT neighbours
        // Neighbours' values in JSON file
        foreach(int n in jsonObject.ObjectPlaced[clickedTile.ObjectIndex].Neighbours.RightNeighbours) {
            neighboursObjectsIndexes.Add(n);
        }

        // Neighbours' values in the grid
        if(clickedTile.Neighbours[2] == -1) {
            if(!neighboursObjectsIndexes.Contains(0)) {
                validObject = false;
            }
        }
        else {
            if(!neighboursObjectsIndexes.Contains(grid[clickedTile.Neighbours[2]].ObjectIndex)) {
                validObject = false;
            }
        }

        neighboursObjectsIndexes.Clear();

        // Check BOTTOM neighbours
        // Neighbours' values in JSON file
        foreach(int n in jsonObject.ObjectPlaced[clickedTile.ObjectIndex].Neighbours.BottomNeighbours) {
            neighboursObjectsIndexes.Add(n);
        }

        // Neighbours' values in the grid
        if(clickedTile.Neighbours[3] == -1) {
            if(!neighboursObjectsIndexes.Contains(0)) {
                validObject = false;
            }
        }
        else {
            if(!neighboursObjectsIndexes.Contains(grid[clickedTile.Neighbours[3]].ObjectIndex)) {
                validObject = false;
            }
        }

        neighboursObjectsIndexes.Clear();

        if(!validObject) {
            NextReplacement(jsonObject.ObjectPlaced[clickedTile.ObjectIndex], 0, grid, clickedTile);
        }
    }

    private void NextReplacement(ObjectPlaced objectPlaced, int replacementIndex, List<Tile> grid, Tile checkingTile) // Tile neighbours order: [Top, Left, Right, Bottom]
    {
        List<int> neighboursObjectsIndexes = new List<int>();
        bool validObject = true;

        try {
            Replacement replacement = objectPlaced.Replacements[replacementIndex];

            // Check TOP neighbours
            foreach(int n in replacement.Neighbours.TopNeighbours) {
                neighboursObjectsIndexes.Add(n);
            }

            if(checkingTile.Neighbours[0] == -1) {
                if(!neighboursObjectsIndexes.Contains(0)) {
                    validObject = false;
                }
            }
            else {
                if(!neighboursObjectsIndexes.Contains(grid[checkingTile.Neighbours[0]].ObjectIndex)) {
                    validObject = false;
                }
            }

            neighboursObjectsIndexes.Clear();

            // Check LEFT neighbours
            foreach(int n in replacement.Neighbours.LeftNeighbours) {
                neighboursObjectsIndexes.Add(n);
            }

            if(checkingTile.Neighbours[1] == -1) {
                if(!neighboursObjectsIndexes.Contains(0)) {
                    validObject = false;
                }
            }
            else {
                if(!neighboursObjectsIndexes.Contains(grid[checkingTile.Neighbours[1]].ObjectIndex)) {
                    validObject = false;
                }
            }

            neighboursObjectsIndexes.Clear();

            // Check RIGHT neighbours
            foreach(int n in replacement.Neighbours.RightNeighbours) {
                neighboursObjectsIndexes.Add(n);
            }

            if(checkingTile.Neighbours[2] == -1) {
                if(!neighboursObjectsIndexes.Contains(0)) {
                    validObject = false;
                }
            }
            else {
                if(!neighboursObjectsIndexes.Contains(grid[checkingTile.Neighbours[2]].ObjectIndex)) {
                    validObject = false;
                }
            }

            neighboursObjectsIndexes.Clear();

            // Check BOTTOM neighbours
            foreach(int n in replacement.Neighbours.BottomNeighbours) {
                neighboursObjectsIndexes.Add(n);
            }

            if(checkingTile.Neighbours[3] == -1) {
                if(!neighboursObjectsIndexes.Contains(0)) {
                    validObject = false;
                }
            }
            else {
                if(!neighboursObjectsIndexes.Contains(grid[checkingTile.Neighbours[3]].ObjectIndex)) {
                    validObject = false;
                }
            }

            neighboursObjectsIndexes.Clear();

            if(!validObject) {
                NextReplacement(objectPlaced, ++replacementIndex, grid, checkingTile);
            }
            else {
                print("Replacement found! -> Replacement object: " + replacement.Name + " (" + replacement.Index + ")");
                checkingTile.ChangeObject(replacement.Index);
            }
        }
        catch {
            Debug.LogError("There are no more valid replacements for object: '" + objectPlaced.Name + "' in tile: " + checkingTile.TileId);
        }
    }
}