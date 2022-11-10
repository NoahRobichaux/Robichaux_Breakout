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
    
    public string levelName;


    void Start()
    {
        livesText.SetText("Lives: " + lives);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
