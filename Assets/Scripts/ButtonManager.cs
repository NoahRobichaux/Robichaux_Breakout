using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameManager gameManagerScript;
public void ButtonPressSFX(bool play)
    {
        gameManagerScript.barBreakObject.SetActive(true);
    }
}
