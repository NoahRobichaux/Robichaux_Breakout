using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.IO;
using System.Text;

public class GameManager : MonoBehaviour
{
    public TMP_Text livesText;
    public TMP_Text scoreText;
    
    public int lives;

    public struct SaticIntegers
    {
        public static int score;
        public static int highScore;
        public static int isGameLost;
    }
    
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

    void Start()
    {
        startText.SetActive(true);
        scoreText.SetText("Score: " + GameManager.SaticIntegers.score);
        livesText.SetText("Lives: " + lives);
        loadLevelDelay = 5f;
        loadMainMenuDelay = 3f;
        GameManager.SaticIntegers.score = 0;
        GameManager.SaticIntegers.isGameLost = 0;
        maxScore = 256;
        lives = 3;
        barsBroken = 0;
        LevelOne = SceneManager.GetSceneByName("LevelOne");
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
            if (GameManager.SaticIntegers.score < maxScore)
            {
                playerBar.GetComponent<Transform>().localScale = new Vector3(0.5f, 1, 1);
            }
        }
        if (barsBroken == 64)
        {
            if (loadLevelDelay > 0 && lives > 0 && GameManager.SaticIntegers.score == maxScore)
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
            lives = 2;
            livesText.SetText("Lives: 2");
            lostLifeObject.SetActive(true);
            startText.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && lives == 2)
        {
            isPlayerDead = false;
        }
        if (isPlayerDead && lives == 2)
        {
            lives = 1;
            livesText.SetText("Lives: 1");
            lostLifeObject.SetActive(true);
            startText.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && lives == 1)
        {
            isPlayerDead = false;
        }
        if (isPlayerDead && lives == 1)
        {
            livesText.SetText("Lives: 0");
            lives = 0;
        }
        if (isPlayerDead && lives == 0)
        {
            if (loadMainMenuDelay > 0)
            {
                loadMainMenuDelay -= Time.deltaTime;
                loseText.SetActive(true);
                gameOverObject.SetActive(true);
                GameManager.SaticIntegers.isGameLost = 1;
                PlayerPrefs.SetInt("Score", GameManager.SaticIntegers.score);
                PlayerPrefs.SetInt("High Score", GameManager.SaticIntegers.highScore);
                PlayerPrefs.SetInt("Is Game Lost", GameManager.SaticIntegers.isGameLost);
                DontDestroyOnLoad(gameManagerObject);
                DontDestroyOnLoad(gameManagerObject.GetComponent<GameManager>());
            }
            if (loadMainMenuDelay <= 0)
            {
                SceneManager.LoadScene(mainMenuScene);
            }
        }
    }
    void OnEnable()
    {
        DontDestroyOnLoad(gameManagerObject);
        DontDestroyOnLoad(gameManagerObject.GetComponent<GameManager>());
    }
    void OnDisable()
    {
        PlayerPrefs.SetInt("Score", GameManager.SaticIntegers.score);
        PlayerPrefs.SetInt("High Score", GameManager.SaticIntegers.highScore);
        PlayerPrefs.SetInt("Is Game Lost", GameManager.SaticIntegers.isGameLost);
        DontDestroyOnLoad(gameManagerObject);
        DontDestroyOnLoad(gameManagerObject.GetComponent<GameManager>());
    }
}