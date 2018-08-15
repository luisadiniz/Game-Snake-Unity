using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    public void PlayGame(float newVelocity) {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetFloat("Velocity", newVelocity);
    }

    public void RestartGame() {
        SceneManager.LoadScene(1);
    }

}
