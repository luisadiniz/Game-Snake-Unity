using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUpDate : MonoBehaviour {

    public Text gameOverText;
    public Text scoreText;
    public Text highScoreText;

    [SerializeField]
    private int score;
    [SerializeField]
    private int highScore;

    private string scoreKey = "HighScore";

    public void Start()
	{
        gameOverText.text = "";

        score = 0;
        UpdateScore();

        highScore = PlayerPrefs.GetInt(scoreKey);
        UpdateHighScoreUI();
	}

    // adiciona o valor no score
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    // converter o score para uma string no jogo
    public void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }

    public void UpdateHighScoreUI()
    {
        highScoreText.text = "High Score : " + highScore;
    }

    public void StoreHighscore()
    {
        int oldScore = PlayerPrefs.GetInt(scoreKey);

        if (score > oldScore)
        {
            PlayerPrefs.SetInt(scoreKey, score);
            highScore = score;

        }
    }

    public void GameOverText(){
        gameOverText.text = "Game Over!";
    }

    public void ResetHighScore() 
    {
        PlayerPrefs.SetInt(scoreKey, 0);
    }

}