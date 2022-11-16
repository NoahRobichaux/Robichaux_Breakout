using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Breakout : MonoBehaviour
{
    public GameManager gameManagerScript;
    public Scene mainMenu;

    public static TMP_Text highScoreText;
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
        DataSaver.loadData<PlayerSaveData>("Save Data");
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
        MainMenu_Breakout.SaticIntegers.score = PlayerPrefs.GetInt("Score");
        MainMenu_Breakout.SaticIntegers.highScore = PlayerPrefs.GetInt("High Score");
        MainMenu_Breakout.SaticIntegers.isGameLost = PlayerPrefs.GetInt("Is Game Lost");
    }
    void OnDisable()
    {
        PlayerPrefs.SetInt("Score", MainMenu_Breakout.SaticIntegers.score);
        PlayerPrefs.SetInt("High Score", MainMenu_Breakout.SaticIntegers.highScore);
        PlayerPrefs.SetInt("Is Game Lost", MainMenu_Breakout.SaticIntegers.isGameLost);
    }
    public void LoadLevel(string level)
    {
        DataSaver.saveData(PlayerSaveData.saveData, "Save Data");
        SceneManager.LoadScene(level);
    }
}
public class MainMenuSaveData
{
    public static PlayerSaveData loadedData = DataSaver.loadData<PlayerSaveData>("Save Data");

    private void Start()
    {
        if (loadedData.isGameLost == 1)
        {
            loadedData.score = loadedData.highScore;
        }
        else if (loadedData.score == 0)
        {
            return;
        }
    }
    private void Update()
    {
        if (loadedData.score == 0)
        {
            MainMenu_Breakout.highScoreText.SetText("No High Score");
        }
        else if (loadedData.highScore > 0 && loadedData.isGameLost == 1)
        {
            MainMenu_Breakout.highScoreText.SetText("High Score: " + loadedData.highScore);
        }
    }
}