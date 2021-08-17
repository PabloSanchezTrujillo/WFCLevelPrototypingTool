using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    [SerializeField] private GameObject importMenu;
    [SerializeField] private GameObject gridOptionsMenu;
    [SerializeField] private Text inputFileName;
    [SerializeField] private GridGenerator gridGenerator;

    public void LoadMenu()
    {
        importMenu.SetActive(true);
    }

    public void QuitLoadMenu()
    {
        importMenu.SetActive(false);
    }

    public void LoadFile()
    {
        if(File.Exists(Application.dataPath + "/Savings/" + inputFileName.text + ".json")) {
            string loadedFile = File.ReadAllText(Application.dataPath + "/Savings/" + inputFileName.text + ".json");

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(loadedFile);
            StartCoroutine(SetUpScene(saveObject));
        }
        else {
            Debug.LogError("File not found");
        }
    }

    private IEnumerator SetUpScene(SaveObject saveObject)
    {
        gridGenerator.SetRowsAndCols(saveObject.Rows, saveObject.Cols);
        gridGenerator.GenerateGrid();

        yield return new WaitUntil(() => gridGenerator.GridInitialised == true);

        for(int i = 0; i < gridGenerator.transform.childCount; i++) {
            Tile tile = gridGenerator.transform.GetChild(i).GetComponent<Tile>();

            if(tile.TileId == saveObject.Tiles[i].TileId) {
                tile.LoadTile(saveObject.Tiles[i].ObjectIndex);
            }
        }

        importMenu.SetActive(false);
        gridOptionsMenu.SetActive(false);
    }
}