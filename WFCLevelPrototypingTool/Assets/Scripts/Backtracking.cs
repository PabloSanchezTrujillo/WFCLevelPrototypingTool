using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backtracking : MonoBehaviour
{
    public bool BacktrackGrid(List<int> gridIndex, List<int[]> gridConnections, int start, List<int> visited, List<int> path)
    {
        // The algorithm has visited all the grid
        if(visited.Count == gridIndex.Count) {
            ShowPath(path);
            return true;
        }

        // Check if visited doesn't have the start value
        if(!visited.Contains(start)) {
            visited.Add(start);
        }
        int[] neighbours = gridConnections[start];

        foreach(int i in neighbours) {
            if(!visited.Contains(i)) {
                if(BacktrackGrid(gridIndex, gridConnections, i, visited, path)) {
                    path.Add(start);
                    return true;
                }
            }
        }

        return false;
    }

    public void BacktrackGrid(List<Tile> grid, List<int> visited, int tileId)
    {
        Queue<int> queue = new Queue<int>();
        string path = "Path: ";

        queue.Enqueue(tileId);
        visited.Add(tileId);

        while(queue.Count != 0) {
            int tile = queue.Peek();
            path += grid[tile].TileId + " - ";
            queue.Dequeue();

            foreach(int neighbour in grid[tile].Neighbours) {
                if(!visited.Contains(neighbour)) {
                    queue.Enqueue(neighbour);
                    visited.Add(neighbour);
                }
            }
        }
        path += "[ " + visited.Count.ToString() + " ]";

        print(path);
    }

    private void ShowPath(List<int> path)
    {
        string printPath = "Path: ";

        foreach(int i in path) {
            printPath += i + ", ";
        }

        print(printPath);
    }
}