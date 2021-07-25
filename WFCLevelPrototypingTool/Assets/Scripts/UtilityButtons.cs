using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityButtons : MonoBehaviour
{
    [SerializeField] private GameObject cameraPivot;

    private bool gridOn = true;

    public void ClearTheGrid()
    {
        for(int i = 0; i < transform.childCount; i++) {
            if(transform.GetChild(i).GetComponent<Tile>().Occupied) {
                transform.GetChild(i).GetComponent<Tile>().DeleteObject();
            }
        }
    }

    public void ToggleGrid()
    {
        if(gridOn) {
            for(int i = 0; i < transform.childCount; i++) {
                for(int j = 0; j < 4; j++) {
                    transform.GetChild(i).GetChild(j).gameObject.SetActive(false);
                }
            }

            gridOn = false;
        }
        else {
            for(int i = 0; i < transform.childCount; i++) {
                for(int j = 0; j < 4; j++) {
                    transform.GetChild(i).GetChild(j).gameObject.SetActive(true);
                }
            }

            gridOn = true;
        }
    }

    public void CenterCamera()
    {
        cameraPivot.transform.position = Vector3.zero;
    }
}