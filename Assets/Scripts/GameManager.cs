using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

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
        livesText.SetText("Lives: " + lives);
        startText.SetActive(true);
        loadLevelDelay = 5.0f;
        loadMainMenuDelay = 3.0f;
        score = 0;
        barsBroken = 0;
        scoreText.SetText("0" + score);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startText.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
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
        if (isPlayerDead)
        {
            lives -= lives -2;
            livesText.SetText("Lives: " + lives);
            lostLifeObject.SetActive(true);
            if (lives < 3 && lives > 0)
            {
                Time.timeScale = 0;
                startText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Time.timeScale = 1;
                    isPlayerDead = false;
                }
            }
        }
        if (lives == 0)
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
