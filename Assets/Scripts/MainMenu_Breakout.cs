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
    }
    void Start()
    {
        mainMenu = SceneManager.GetSceneByName("MainMenu");
    }
    void Update()
    {
        if (MainMenu_Breakout.SaticIntegers.score == 0)
        {
            highScoreText.SetText("No High Score");
        }
        else if (MainMenu_Breakout.SaticIntegers.highScore > 0)
        {
            highScoreText.SetText("High Score: " + MainMenu_Breakout.SaticIntegers.highScore);
        }
    }
    void OnEnable()
    {
        MainMenu_Breakout.SaticIntegers.score = PlayerPrefs.GetInt("Score");
        MainMenu_Breakout.SaticIntegers.highScore = PlayerPrefs.GetInt("High Score");
    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}