using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWall : MonoBehaviour
{
    public GameObject winWall;
    public GameManager gameManagerScript;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Puck")
        {
            gameManagerScript.isPuckOnWinWall = true;
        }
    }
}
