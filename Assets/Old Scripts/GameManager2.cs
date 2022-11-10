using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text coinText;
    public int coinTotal;
    public int coinWinCon;
    public int coinValue;
    public AudioSource coinSound;

    public GameObject congratsObject;
    public GameObject gameOverObject;

    public bool isPlayerDead;

    public string levelName;

    // Update is called once per frame
    void Update()
    {
        coinText.SetText("x " + coinTotal);
        if (coinTotal == coinWinCon)
        {
            congratsObject.SetActive(true);
            SceneManager.LoadScene(levelName);
        }
        if (isPlayerDead)
        {
            gameOverObject.SetActive(true);
        }
    }
}
