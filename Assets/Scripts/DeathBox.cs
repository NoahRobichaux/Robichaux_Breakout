using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public GameManager gameManagerScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManagerScript.isPlayerDead = true;
        if (gameManagerScript.lives <= 3)
        {
            gameManagerScript.lostLife.Play();
            collision.gameObject.GetComponent<Transform>().localPosition = Vector2.zero;
        }
        else if (gameManagerScript.lives == 0)
        {
            gameManagerScript.gameOver.Play();
        }  
    }
}
