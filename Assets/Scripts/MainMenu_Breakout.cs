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
    }
    public void Start()
    {
        MainMenu_Breakout.SaticIntegers.score = MainMenu_Breakout.SaticIntegers.highScore;
        SaveManager.score = SaveManager.highScore;
        MainMenu_Breakout.SaticIntegers.score += SaveManager.highScore;

        mainMenu = SceneManager.GetSceneByName("MainMenu");
        highScoreObject = GameObject.FindGameObjectWithTag("HighScoreText");
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
        else if (MainMenu_Breakout.SaticIntegers.highScore > 0)
        {
            highScoreText.SetText("High Score: " + MainMenu_Breakout.SaticIntegers.highScore);
            MainMenu_Breakout.SaticIntegers.score = SaveManager.highScore;
        }
    }
    void OnEnable()
    {
        SaveManager.score = SaveManager.highScore;
        MainMenu_Breakout.SaticIntegers.score += SaveManager.highScore;
    }
    void OnDisable()
    {
        SaveManager.score = SaveManager.highScore;
        MainMenu_Breakout.SaticIntegers.score += SaveManager.highScore;
    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
public class MainMenuSaveData : MonoBehaviour
{
    public MainMenu_Breakout mainMenu;
    public TMP_Text highScoreText;
    public GameObject highScoreObject;

    void Start()
    {
        highScoreObject = GameObject.FindGameObjectWithTag("HighScoreText");
    }
    void Update()
    {

    }
}