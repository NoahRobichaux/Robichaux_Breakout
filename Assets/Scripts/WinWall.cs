using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWall : MonoBehaviour
{

    public GameManager gameManagerScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManagerScript.isPuckOnWinWall = true;
    }
}
