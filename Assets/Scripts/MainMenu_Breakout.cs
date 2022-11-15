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
        highScoreText.SetText("No High Score");
        MainMenu = SceneManager.GetSceneByName("MainMenu");
    }

    void Update()
    {
        if (MainMenu.isLoaded)
        {
            gameManagerScript.highScore = gameManagerScript.score;
            if (gameManagerScript.highScore > 0)
            {
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