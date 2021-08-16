using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadRacetrack(AudioClip clickBuutton)
    {
        audioSource.clip = clickBuutton;
        audioSource.Play();

        SceneManager.LoadScene((int)Scenes.ScenesOrder.RacetrackScene);
    }

    public void LoadCity(AudioClip clickButton)
    {
        audioSource.clip = clickButton;
        audioSource.Play();

        SceneManager.LoadScene((int)Scenes.ScenesOrder.CityScene);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene((int)Scenes.ScenesOrder.MainMenu);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}