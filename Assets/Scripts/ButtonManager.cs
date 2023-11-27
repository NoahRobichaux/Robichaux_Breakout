using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameManager gameManagerScript;
    public AudioSource buttonHoverSFX;
    public GameObject buttonManagerObject;
    
    public Button playButton;
    public Button exitButton;
    public Button levelOneButton;
    public Button levelTwoButton;
    public Button levelThreeButton;
    public Button returnButton;
    public Button resumeButton;
    public Button pauseButton;
    public Button restartButton;
    public Button levelSelectButton;
    
    public float buttonPressSFXDelay = 0.5f;
    public float buttonHoverSFXDelay = 0.5f;

    private void Update()
    {
        DontDestroyOnLoad(buttonManagerObject);
    }

    public void ButtonPressSFX(bool play)
    {
        gameManagerScript.barBreakObject.SetActive(true);
        gameManagerScript.barBreak.Play();
        if (gameManagerScript.barBreak.isActiveAndEnabled)
        {
            buttonPressSFXDelay -= Time.deltaTime;
            if (buttonPressSFXDelay <= 0)
            {
                gameManagerScript.barBreakObject.SetActive(false);
            }
        }
    }
    public void ButtonHoverSFX(bool play)
    {
        if (playButton.GetComponent<Button>().spriteState.highlightedSprite == true)
        {
            buttonHoverSFX.gameObject.SetActive(true);
            buttonHoverSFX.Play();
            if (buttonHoverSFX.isActiveAndEnabled)
            {
                buttonHoverSFXDelay -= Time.deltaTime;
                if (buttonHoverSFXDelay <= 0)
                {
                    buttonHoverSFX.gameObject.SetActive(false);
                }
            }
        }
        if (exitButton.GetComponent<Button>().spriteState.highlightedSprite == true)
        {
            buttonHoverSFX.gameObject.SetActive(true);
            buttonHoverSFX.Play();
            if (buttonHoverSFX.isActiveAndEnabled)
            {
                buttonHoverSFXDelay -= Time.deltaTime;
                if (buttonHoverSFXDelay <= 0)
                {
                    buttonHoverSFX.gameObject.SetActive(false);
                }
            }
        }
        if (levelOneButton.GetComponent<Button>().spriteState.highlightedSprite == true)
        {
            buttonHoverSFX.gameObject.SetActive(true);
            buttonHoverSFX.Play();
            if (buttonHoverSFX.isActiveAndEnabled)
            {
                buttonHoverSFXDelay -= Time.deltaTime;
                if (buttonHoverSFXDelay <= 0)
                {
                    buttonHoverSFX.gameObject.SetActive(false);
                }
            }
        }
        if (levelTwoButton.GetComponent<Button>().spriteState.highlightedSprite == true)
        {
            buttonHoverSFX.gameObject.SetActive(true);
            buttonHoverSFX.Play();
            if (buttonHoverSFX.isActiveAndEnabled)
            {
                buttonHoverSFXDelay -= Time.deltaTime;
                if (buttonHoverSFXDelay <= 0)
                {
                    buttonHoverSFX.gameObject.SetActive(false);
                }
            }
        }
        if (levelThreeButton.GetComponent<Button>().spriteState.highlightedSprite == true)
        {
            buttonHoverSFX.gameObject.SetActive(true);
            buttonHoverSFX.Play();
            if (buttonHoverSFX.isActiveAndEnabled)
            {
                buttonHoverSFXDelay -= Time.deltaTime;
                if (buttonHoverSFXDelay <= 0)
                {
                    buttonHoverSFX.gameObject.SetActive(false);
                }
            }
        }
        if (returnButton.GetComponent<Button>().spriteState.highlightedSprite == true)
        {
            buttonHoverSFX.gameObject.SetActive(true);
            buttonHoverSFX.Play();
            if (buttonHoverSFX.isActiveAndEnabled)
            {
                buttonHoverSFXDelay -= Time.deltaTime;
                if (buttonHoverSFXDelay <= 0)
                {
                    buttonHoverSFX.gameObject.SetActive(false);
                }
            }
        }
        if (resumeButton.GetComponent<Button>().spriteState.highlightedSprite == true)
        {
            buttonHoverSFX.gameObject.SetActive(true);
            buttonHoverSFX.Play();
            if (buttonHoverSFX.isActiveAndEnabled)
            {
                buttonHoverSFXDelay -= Time.deltaTime;
                if (buttonHoverSFXDelay <= 0)
                {
                    buttonHoverSFX.gameObject.SetActive(false);
                }
            }
        }
        if (pauseButton.GetComponent<Button>().spriteState.highlightedSprite == true)
        {
            buttonHoverSFX.gameObject.SetActive(true);
            buttonHoverSFX.Play();
            if (buttonHoverSFX.isActiveAndEnabled)
            {
                buttonHoverSFXDelay -= Time.deltaTime;
                if (buttonHoverSFXDelay <= 0)
                {
                    buttonHoverSFX.gameObject.SetActive(false);
                }
            }
        }
        if (restartButton.GetComponent<Button>().spriteState.highlightedSprite == true)
        {
            buttonHoverSFX.gameObject.SetActive(true);
            buttonHoverSFX.Play();
            if (buttonHoverSFX.isActiveAndEnabled)
            {
                buttonHoverSFXDelay -= Time.deltaTime;
                if (buttonHoverSFXDelay <= 0)
                {
                    buttonHoverSFX.gameObject.SetActive(false);
                }
            }
        }
        if (levelSelectButton.GetComponent<Button>().spriteState.highlightedSprite == true)
        {
            buttonHoverSFX.gameObject.SetActive(true);
            buttonHoverSFX.Play();
            if (buttonHoverSFX.isActiveAndEnabled)
            {
                buttonHoverSFXDelay -= Time.deltaTime;
                if (buttonHoverSFXDelay <= 0)
                {
                    buttonHoverSFX.gameObject.SetActive(false);
                }
            }
        }
    }
}
