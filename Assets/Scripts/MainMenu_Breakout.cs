using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Breakout : MonoBehaviour
{
    public GameManager gameManagerScript;
    public TMP_Text highScoreText;
    void Start()
    {
        highScoreText.SetText("No High Score");
    }

    void Update()
    {
        if (DataSaver.loadData<PlayerSaveData>("Save Data").highScore == 0)
        {
            highScoreText.SetText("No High Score");
        }
        if (DataSaver.loadData<PlayerSaveData>("Save Data").highScore > 0)
        {
            DataSaver.loadData<PlayerSaveData>("Save Data").score = DataSaver.loadData<PlayerSaveData>("Save Data").highScore;
            highScoreText.SetText("High Score: " + DataSaver.loadData<PlayerSaveData>("Save Data").highScore);
        }
    }
    public void LoadData()
    {
        PlayerSaveData loadedData = DataSaver.loadData<PlayerSaveData>("Save Data");
        if (loadedData == null)
        {
            return;
        }
        for (int i = 0; i < loadedData.ID.Count; i++)
        {
            Debug.Log("ID: " + loadedData.ID[i]);
        }
        for (int i = 0; i < loadedData.Amounts.Count; i++)
        {
            Debug.Log("Amounts: " + loadedData.Amounts[i]);
        }
    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}