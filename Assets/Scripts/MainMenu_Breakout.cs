using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_Breakout : MonoBehaviour
{
    public GameManager gameManagerScript;
    public Scene mainMenu;

    public TMP_Text highScoreText;
    public GameObject highScoreObject;

    public GameObject playButton;
    public GameObject exitButton;
    public struct SaticIntegers
    {
        public static int score;
        public static int highScore;
        public static int isGameLost;
    }
    public void Start()
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
        highScoreObject = GameObject.FindGameObjectWithTag("HighScoreText");
        DontDestroyOnLoad(highScoreObject);
        DontDestroyOnLoad(playButton);
        DontDestroyOnLoad(exitButton);
        playButton.gameObject.SetActive(true);
        playButton.gameObject.GetComponent<Button>().interactable = true;
        exitButton.gameObject.SetActive(true);
        exitButton.gameObject.GetComponent<Button>().interactable = true;
    }
    public void Update()
    {
        if (MainMenu_Breakout.SaticIntegers.score == 0)
        {
            highScoreText.SetText("No High Score");
        }
        else if (MainMenu_Breakout.SaticIntegers.highScore > 0 && MainMenu_Breakout.SaticIntegers.isGameLost == 1)
        {
            highScoreText.SetText("High Score: " + MainMenu_Breakout.SaticIntegers.highScore);
        }
        DontDestroyOnLoad(highScoreObject);
        DontDestroyOnLoad(playButton);
        DontDestroyOnLoad(exitButton);
    }
    void OnEnable()
    {
        MainMenu_Breakout.SaticIntegers.score = PlayerPrefs.GetInt("Score");
        MainMenu_Breakout.SaticIntegers.highScore = PlayerPrefs.GetInt("High Score");
        MainMenu_Breakout.SaticIntegers.isGameLost = PlayerPrefs.GetInt("Is Game Lost");
        DontDestroyOnLoad(highScoreObject);
        DontDestroyOnLoad(playButton);
        DontDestroyOnLoad(exitButton);
    }
    void OnDisable()
    {
        PlayerPrefs.SetInt("Score", MainMenu_Breakout.SaticIntegers.score);
        PlayerPrefs.SetInt("High Score", MainMenu_Breakout.SaticIntegers.highScore);
        PlayerPrefs.SetInt("Is Game Lost", MainMenu_Breakout.SaticIntegers.isGameLost);
        DontDestroyOnLoad(highScoreObject);
        DontDestroyOnLoad(playButton);
        DontDestroyOnLoad(exitButton);
    }
    public void LoadLevel(string level)
    {
        DataSaver.saveData(PlayerSaveData.saveData, "Save Data");
        SceneManager.LoadScene(level);
    }
}
public class MainMenuSaveData : MonoBehaviour
{
    public MainMenu_Breakout mainMenu;
    public static PlayerSaveData loadedData = DataSaver.loadData<PlayerSaveData>("Save Data");
    public TMP_Text highScoreText;
    public GameObject highScoreObject;

    void Start()
    {
        if (loadedData.isGameLost == 1)
        {
            loadedData.score = loadedData.highScore;
        }
        else if (loadedData.score == 0)
        {
            return;
        }
        highScoreObject = GameObject.FindGameObjectWithTag("HighScoreText");
    }
    void Update()
    {
        if (loadedData.score == 0)
        {
            highScoreText.SetText("No High Score");
        }
        else if (loadedData.highScore > 0 && loadedData.isGameLost == 1)
        {
            highScoreText.SetText("High Score: " + loadedData.highScore);
        }
    }
    void OnEnable()
    {
        DontDestroyOnLoad(highScoreText);
        DontDestroyOnLoad(highScoreObject);
    }
    void OnDisable()
    {
        DontDestroyOnLoad(highScoreText);
        DontDestroyOnLoad(highScoreObject);
    }
}