using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Breakout : MonoBehaviour
{
    public GameManager gameManagerScript;
    public TMP_Text highScoreText;

    public Scene MainMenu;
    void Start()
    {
        MainMenu = SceneManager.GetSceneByName("MainMenu");
        if (MainMenu.isLoaded)
        {
            highScoreText.SetText("No High Score");
        }
    }

    void Update()
    {
        if (MainMenu.isLoaded)
        {
            if (gameManagerScript.highScore > 0)
            {
                gameManagerScript.highScore = gameManagerScript.score;
                highScoreText.SetText("High Score: " + gameManagerScript.highScore);
            }
            else if (gameManagerScript.highScore == 0)
            {
                highScoreText.SetText("No High Score");
            }
        }
    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}