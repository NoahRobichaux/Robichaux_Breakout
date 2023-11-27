using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_Breakout : MonoBehaviour
{
    public GameManager gameManagerScript;

    public TMP_Text highScoreText;
    public GameObject highScoreObject;

    public GameObject playButton;
    public GameObject exitButton;

    public static int score;
    public static int highScore;

    public void Start()
    {
        score = highScore;
        SaveManager.score = SaveManager.highScore;
        score += SaveManager.highScore;
        highScoreObject = GameObject.FindGameObjectWithTag("HighScoreText");
        playButton.gameObject.SetActive(true);
        playButton.gameObject.GetComponent<Button>().interactable = true;
        exitButton.gameObject.SetActive(true);
        exitButton.gameObject.GetComponent<Button>().interactable = true;
    }
    public void Update()
    {
        if (score == 0)
        {
            highScoreText.SetText("No High Score");
        }
        else if (highScore > 0)
        {
            highScoreText.SetText("High Score: " + highScore);
            score = SaveManager.highScore;
            SaveManager.score = SaveManager.highScore;
            SaveManager.highScore += score;
        }
    }

    public static void LoadLevel(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
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