using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Breakout : MonoBehaviour
{
    public GameManager gameManagerScript;
    public TMP_Text highScoreText;
    void Start()
    {
        highScoreText.SetText("No Highscore");
    }

    void Update()
    {
        if (gameManagerScript.loadMainMenuDelay <= 0)
        {
            gameManagerScript.highScore = gameManagerScript.score;
            highScoreText.SetText("High Score: " + gameManagerScript.highScore);
        }
    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}