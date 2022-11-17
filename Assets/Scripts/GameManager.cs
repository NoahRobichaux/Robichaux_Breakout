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
    public Scene MainMenu;

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
        MainMenu = SceneManager.GetSceneByName("MainMenu");
        DataSaver.saveData(PlayerSaveData.saveData, "Save Data");
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
            isPlayerDead = false;
        }
        if (isPlayerDead && lives == 2)
        {
            lives = 1;
            livesText.SetText("Lives: 1");
            lostLifeObject.SetActive(true);
            startText.SetActive(true);
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
                DataSaver.saveData(PlayerSaveData.saveData, "Save Data");
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
        if (LevelOne.isLoaded == true)
        {
            DontDestroyOnLoad(gameManagerObject);
            DontDestroyOnLoad(gameManagerObject.GetComponent<GameManager>());
            DataSaver.loadData<PlayerSaveData>("Save Data");
        }
        else if (MainMenu.isLoaded)
        {
            DontDestroyOnLoad(gameManagerObject);
            DontDestroyOnLoad(gameManagerObject.GetComponent<GameManager>());
            DataSaver.loadData<PlayerSaveData>("Save Data");
        }
    }
    void OnDisable()
    {
        if (LevelOne.isLoaded == true)
        {
            PlayerPrefs.SetInt("Score", GameManager.SaticIntegers.score);
            PlayerPrefs.SetInt("High Score", GameManager.SaticIntegers.highScore);
            PlayerPrefs.SetInt("Is Game Lost", GameManager.SaticIntegers.isGameLost);
            DontDestroyOnLoad(gameManagerObject);
            DontDestroyOnLoad(gameManagerObject.GetComponent<GameManager>());
        }
        else if (MainMenu.isLoaded)
        {
            PlayerPrefs.SetInt("Score", GameManager.SaticIntegers.score);
            PlayerPrefs.SetInt("High Score", GameManager.SaticIntegers.highScore);
            PlayerPrefs.SetInt("Is Game Lost", GameManager.SaticIntegers.isGameLost);
            DontDestroyOnLoad(gameManagerObject);
            DontDestroyOnLoad(gameManagerObject.GetComponent<GameManager>());
        }
        DataSaver.saveData(PlayerSaveData.saveData, "SaveData");
    }
}

[Serializable]
public class PlayerSaveData
{
    public List<int> ID = new List<int>();
    public List<int> Amounts = new List<int>();
    public GameManager gameManagerScript;
    public int score;
    public int highScore;
    public int isGameLost;
    public static PlayerSaveData saveData;
    public void SaveData()
    {
        saveData = new PlayerSaveData();
        saveData.score = GameManager.SaticIntegers.score;
        saveData.highScore = GameManager.SaticIntegers.highScore;
        saveData.isGameLost = GameManager.SaticIntegers.isGameLost;

        DataSaver.saveData(saveData, "Save Data");
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
    public void DeleteData()
    {
        DataSaver.deleteData("Save Data");
    }
}
public class DataSaver
{
    //Save Data
    public static void saveData<T>(T dataToSave, string dataFileName)
    {
        string tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".txt");

        //Convert To Json then to bytes
        string jsonData = JsonUtility.ToJson(dataToSave, true);
        byte[] jsonByte = Encoding.ASCII.GetBytes(jsonData);

        //Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        }
        //Debug.Log(path);

        try
        {
            File.WriteAllBytes(tempPath, jsonByte);
            Debug.Log("Saved Data to: " + tempPath.Replace("/", "\\"));
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To PlayerInfo Data to: " + tempPath.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }
    }

    //Load Data
    public static T loadData<T>(string dataFileName)
    {
        string tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".txt");

        //Exit if Directory or File does not exist
        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            Debug.LogWarning("Directory does not exist");
            return default(T);
        }

        if (!File.Exists(tempPath))
        {
            Debug.Log("File does not exist");
            return default(T);
        }

        //Load saved Json
        byte[] jsonByte = null;
        try
        {
            jsonByte = File.ReadAllBytes(tempPath);
            Debug.Log("Loaded Data from: " + tempPath.Replace("/", "\\"));
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To Load Data from: " + tempPath.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }

        //Convert to json string
        string jsonData = Encoding.ASCII.GetString(jsonByte);

        //Convert to Object
        object resultValue = JsonUtility.FromJson<T>(jsonData);
        return (T)Convert.ChangeType(resultValue, typeof(T));
    }

    public static bool deleteData(string dataFileName)
    {
        bool success = false;

        //Load Data
        string tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, dataFileName + ".txt");

        //Exit if Directory or File does not exist
        if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            Debug.LogWarning("Directory does not exist");
            return false;
        }

        if (!File.Exists(tempPath))
        {
            Debug.Log("File does not exist");
            return false;
        }

        try
        {
            File.Delete(tempPath);
            Debug.Log("Data deleted from: " + tempPath.Replace("/", "\\"));
            success = true;
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To Delete Data: " + e.Message);
        }

        return success;
    }
}