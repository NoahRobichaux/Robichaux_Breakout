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
    public int score;
    public int maxScore;
    
    public int highScore;

    public int barsBroken;

    public bool isPuckOnWinWall;
    
    public string nextLevel;

    public string mainMenuScene;

    public float loadLevelDelay;

    public float loadMainMenuDelay;

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


    void Start()
    {
        
        startText.SetActive(true);
        loadLevelDelay = 5.0f;
        loadMainMenuDelay = 3.0f;
        score = 0;
        lives = 3;
        barsBroken = 0;
        scoreText.SetText("" + score);
        livesText.SetText("Lives: " + lives);
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
            if (loadLevelDelay > 0 && lives > 0 && score == maxScore)
            {
                winText.SetActive(true);
                gameWinObject.SetActive(true);
                loadLevelDelay -= Time.deltaTime;
            }
            if (loadLevelDelay <= 0)
            {
                SceneManager.LoadScene(nextLevel);
            }
            if (score < maxScore)
            {
                playerBar.GetComponent<Transform>().localScale = new Vector3(0.5f, 1, 1);
            }
        }
        if (isPlayerDead && lives == 3)
        {
            lives = 2;
            livesText.SetText("Lives: " + lives);
            lostLifeObject.SetActive(true);
            startText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isPlayerDead = false;
            }
        }
        if (isPlayerDead && lives == 2)
        {
            lives = 1; ;
            livesText.SetText("Lives: " + lives);
            lostLifeObject.SetActive(true);
            startText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isPlayerDead = false;
            }
        }
        if (isPlayerDead && lives == 1)
        {
            lives = 0;
            livesText.SetText("Lives: " + lives);
        }
        if (isPlayerDead && lives == 0)
        {
            loseText.SetActive(true);
            gameOverObject.SetActive(true);

            if (loadMainMenuDelay > 0)
            {
                loadMainMenuDelay -= Time.deltaTime;
            }
            if (loadMainMenuDelay <= 0)
            {
                SceneManager.LoadScene(mainMenuScene);
            }
        }
    }
}