using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text livesText;
    public TMP_Text scoreText;
    
    public int lives;

    public int maxScore;

    public int barsBroken;

    public bool isPuckOnWinWall;
    
    public string nextLevel;

    public string mainMenuScene;

    public float loadLevelDelay = 5f;

    public float loadMainMenuDelay = 3f;

    public bool isPlayerDead;

    public Puck puckScript;

    public AudioSource barBreak;
    public GameObject barBreakObject;

    public AudioSource lostLife;
    public GameObject lostLifeObject;

    public AudioSource gameOver;
    public GameObject gameOverObject;

    public AudioSource gameWin;
    public GameObject gameWinObject;

    public AudioSource bGM;
    public GameObject bGMGameObject;

    public GameObject winText;
    public GameObject loseText;
    public GameObject startText;

    public GameObject barContent;

    public GameObject playerBar;

    public GameObject gameManagerObject;

    public Scene LevelOne;
    public Scene LevelTwo;
    public Scene MainMenu;
    public Scene LevelSelect;

    void Start()
    {
        startText.SetActive(true);
        scoreText.SetText("Score: " + SaveManager.score);
        livesText.SetText("Lives: " + lives);
        loadLevelDelay = 5f;
        loadMainMenuDelay = 3f;
        SaveManager.score = 0;
        maxScore = 256;
        lives = 3;
        barsBroken = 0;
        LevelOne = SceneManager.GetSceneByName("LevelOne");
        MainMenu = SceneManager.GetSceneByName("MainMenu");
        LevelSelect = SceneManager.GetSceneByName("LevelSelect");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startText.SetActive(false);
            bGMGameObject.SetActive(true);
        }
        if (isPuckOnWinWall)
        {
            if (SaveManager.score < maxScore)
            {
                playerBar.GetComponent<Transform>().localScale = new Vector3(0.5f, 1, 1);
            }
        }
        if (barsBroken == 64)
        {
            if (loadLevelDelay > 0 && lives > 0 && SaveManager.score == maxScore)
            {
                winText.SetActive(true);
                gameWinObject.SetActive(true);
                loadLevelDelay -= Time.deltaTime;
            }
            if (loadLevelDelay <= 0)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
        if (isPlayerDead && lives == 3)
        {
            lives = 0;
            livesText.SetText("Lives: 2");
            lostLifeObject.SetActive(true);
            startText.SetActive(true);
            isPlayerDead = false;
        }
        if (isPlayerDead && lives == 2)
        {
            lives = 1;
            livesText.SetText("Lives: 1");
            lostLifeObject.SetActive(true);
            startText.SetActive(true);
            isPlayerDead = false;
        }
        if (isPlayerDead && lives == 1)
        {
            livesText.SetText("Lives: 0");
            lives = 0;
        }
        if (lives == 0)
        {
            if (loadMainMenuDelay > 0)
            {
                loadMainMenuDelay -= Time.deltaTime;
                loseText.SetActive(true);
                gameOverObject.SetActive(true);
                MainMenu_Breakout.SaticIntegers.score += SaveManager.score;
            }
            if (loadMainMenuDelay <= 0)
            {
                SceneManager.LoadScene(mainMenuScene);
            }
        }
    }
    void OnEnable()
    {
        if (LevelOne.isLoaded == true)
        {
            MainMenu_Breakout.SaticIntegers.score += SaveManager.score;
        }
        else if (MainMenu.isLoaded == true)
        {
            MainMenu_Breakout.SaticIntegers.score += SaveManager.score;
        }
        else if (LevelSelect.isLoaded == true)
        {
            MainMenu_Breakout.SaticIntegers.score += SaveManager.score;
        }
    }
    void OnDisable()
    {
        if (LevelOne.isLoaded == true)
        {
            MainMenu_Breakout.SaticIntegers.score += SaveManager.score;
        }
        else if (MainMenu.isLoaded == true)
        {
            MainMenu_Breakout.SaticIntegers.score += SaveManager.score;
        }
        else if (LevelSelect.isLoaded == true)
        {
            MainMenu_Breakout.SaticIntegers.score += SaveManager.score;
        }
    }
}