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

    public float delay;
    public bool isTimeUp;

    public bool isPlayerDead;

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
        
        if (isPuckOnWinWall)
        {
            if (delay > 0)
            {
                winText.SetActive(true);
                delay -= Time.deltaTime;
            }
            if (delay <= 0)
            {
                isTimeUp = true;
            }
            if (isTimeUp)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
        if (isPlayerDead)
        {
            lives = lives - 1;
            livesText.SetText("Lives: " + lives);
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
        }
    }
}
