using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Breakout : MonoBehaviour
{
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}