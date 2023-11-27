using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    GameObject[] pauseObjects;

    public void Reload(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            showPaused();
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            hidePaused();
            Time.timeScale = 1;
        }
    }

    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                showPaused();
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                hidePaused();
                Time.timeScale = 1;
            }
        }
    }
}
