using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWall : MonoBehaviour
{
    public GameObject winWall;
    public GameManager gameManagerScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Puck")
        {
            gameManagerScript.isPuckOnWinWall = true;
        }
    }
}
