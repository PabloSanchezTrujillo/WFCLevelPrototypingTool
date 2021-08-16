using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    [SerializeField] private GameObject saveMenu;

    public void SaveMenu()
    {
        saveMenu.SetActive(true);
    }

    public void QuitSaveMenu()
    {
        saveMenu.SetActive(false);
    }
}