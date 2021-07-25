using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] tileSelectorButtons;

    private void Start()
    {
        DisableAllBackgrounds();
    }

    public void SelectNewTile(GameObject selectedTile)
    {
        DisableAllBackgrounds();

        // Sets the ObjectToPlace of all the children to the new selectedTile
        if(selectedTile.CompareTag("EmptyTile")) {
            for(int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).GetChild(4).GetComponentInChildren<TileButton>().ObjectToPlace = null;
            }
        }
        else {
            for(int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).GetChild(4).GetComponentInChildren<TileButton>().ObjectToPlace = selectedTile;
            }
        }
    }

    public void EnableBackground(int index)
    {
        tileSelectorButtons[index].GetComponent<Image>().enabled = true;
    }

    private void DisableAllBackgrounds()
    {
        foreach(GameObject button in tileSelectorButtons) {
            button.GetComponent<Image>().enabled = false;
        }
    }
}