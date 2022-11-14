using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public GameManager gameManagerScript;
    public GameObject puck;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        gameManagerScript.isPlayerDead = true;
        if (gameManagerScript.lives <= 3)
        {
            if (collision.gameObject == puck)
            {
                gameManagerScript.lostLifeObject.SetActive(true);
                collision.gameObject.GetComponent<Transform>().localPosition = Vector2.zero;
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }
        if (gameManagerScript.lives == 0)
        {
            gameManagerScript.gameOverObject.SetActive(true);
        }  
    }
}
