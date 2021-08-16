using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    [SerializeField] private GameObject importMenu;

    public void LoadMenu()
    {
        importMenu.SetActive(true);
    }

    public void QuitLoadMenu()
    {
        importMenu.SetActive(false);
    }
}