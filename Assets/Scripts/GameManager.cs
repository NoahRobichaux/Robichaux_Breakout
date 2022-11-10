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
    public int scoreValue;

    public bool isPuckOnWinWall;
    
    public string nextLevel;

    public float delay;
    public bool isTimeUp;

    public GameObject winText;
    public GameObject loseText;

    public GameObject barContent;


    void Start()
    {
        livesText.SetText("Lives: " + lives);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPuckOnWinWall)
        {
            if (barContent)
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
        }
    }
}
