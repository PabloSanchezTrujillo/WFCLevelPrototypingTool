using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    [SerializeField] private GameObject saveMenu;
    [SerializeField] private GridGenerator gridGenerator;
    [SerializeField] private Text inputFileName;

    public void SaveMenu()
    {
        saveMenu.SetActive(true);
    }

    public void QuitSaveMenu()
    {
        saveMenu.SetActive(false);
    }

    public void SaveFile()
    {
        List<TileData> tilesList = new List<TileData>();

        foreach(Tile tile in gridGenerator.GetChildTiles()) {
            TileData tileData = new TileData
            {
                TileId = tile.TileId,
                ObjectIndex = tile.ObjectIndex
            };

            tilesList.Add(tileData);
        }

        SaveObject saveObject = new SaveObject
        {
            Rows = gridGenerator.GetRows(),
            Cols = gridGenerator.GetCols(),
            Tiles = tilesList.ToArray()
        };

        string json = JsonUtility.ToJson(saveObject);

        if(inputFileName.text == "") {
            File.WriteAllText(Application.dataPath + "/Savings/save.json", json);
        }
        else {
            File.WriteAllText(Application.dataPath + "/Savings/" + inputFileName.text + ".json", json);
        }

        saveMenu.SetActive(false);
    }
}