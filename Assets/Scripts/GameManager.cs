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

    public bool isPuckOnWinWall;
    
    public string nextLevel;

    public string mainMenuScene;

    public float loadLevelDelay = 5;

    public float loadMainMenuDelay = 3;

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


    void Start()
    {
        livesText.SetText("Lives: " + lives);
        startText.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startText.SetActive(false);
            Time.timeScale = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            bGMGameObject.SetActive(true);
            bGM.Play();
        }
        if (isPuckOnWinWall)
        {
            if (loadLevelDelay > 0)
            {
                winText.SetActive(true);
                gameWinObject.SetActive(true);
                gameWin.Play();
                loadLevelDelay -= Time.deltaTime;
            }
            if (loadLevelDelay <= 0)
            {
                SceneManager.LoadScene(nextLevel);
            }

        }
        if (isPlayerDead)
        {
            lives = lives - 1;
            livesText.SetText("Lives: " + lives);
            lostLifeObject.SetActive(true);
            lostLife.Play();
            if (lives < 3)
            {
                Time.timeScale = 0;
                startText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Time.timeScale = 1;
                }
            }
        }
        if (lives <= 0)
        {
            loseText.SetActive(true);
            gameOverObject.SetActive(true);
            gameOver.Play();
            
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
