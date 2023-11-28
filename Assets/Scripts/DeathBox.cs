using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public GameManager gameManagerScript;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManagerScript.lives <= 3)
        {
            if (collision.gameObject.name == "Puck")
            {
                gameManagerScript.isPlayerDead = true;
                gameManagerScript.lostLifeObject.SetActive(true);
                collision.gameObject.GetComponent<Transform>().localPosition = Puck.puckInitPos;
                collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }
        if (gameManagerScript.lives == 0)
        {
            gameManagerScript.gameOverObject.SetActive(true);
        }  
    }
}
