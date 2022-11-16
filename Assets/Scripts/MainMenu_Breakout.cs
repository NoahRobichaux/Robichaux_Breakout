using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Breakout : MonoBehaviour
{
    public GameManager gameManagerScript;
    public TMP_Text highScoreText;
    public Scene mainMenu;
    public struct SaticIntegers
    {
        public static int score;
        public static int highScore;
        public static int isGameLost;
    }
    void Start()
    {
        if (MainMenu_Breakout.SaticIntegers.isGameLost == 1)
        {
            MainMenu_Breakout.SaticIntegers.score = MainMenu_Breakout.SaticIntegers.highScore;
        }
        else if (GameManager.SaticIntegers.isGameLost == 0)
        {
            return;
        }
        mainMenu = SceneManager.GetSceneByName("MainMenu");
    }
    void Update()
    {
        if (MainMenu_Breakout.SaticIntegers.score == 0)
        {
            highScoreText.SetText("No High Score");
        }
        else if (MainMenu_Breakout.SaticIntegers.highScore > 0 && MainMenu_Breakout.SaticIntegers.isGameLost == 1)
        {
            highScoreText.SetText("High Score: " + MainMenu_Breakout.SaticIntegers.highScore);
        }
    }
    void OnEnable()
    {
        if (MainMenu_Breakout.SaticIntegers.isGameLost == 1)
        {
            MainMenu_Breakout.SaticIntegers.score = PlayerPrefs.GetInt("Score");
            MainMenu_Breakout.SaticIntegers.highScore = PlayerPrefs.GetInt("High Score");
            MainMenu_Breakout.SaticIntegers.isGameLost = PlayerPrefs.GetInt("Is Game Lost");
        }
        else if (GameManager.SaticIntegers.isGameLost == 0)
        {
            return;
        }

    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}