using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    public void PlayEasy() {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetFloat("Velocity", 0.15f);
    }

    public void PlayMedium()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetFloat("Velocity", 0.1f);

    }
    public void PlayHard()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetFloat("Velocity", 0.05f);
    }


    public void RestartGameEasy()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetFloat("Velocity", 0.15f);
    }

    public void RestartGameMedium()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetFloat("Velocity", 0.1f);
    }

    public void RestartGameHard()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetFloat("Velocity", 0.05f);
    }
}
