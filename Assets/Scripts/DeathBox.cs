using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public GameManager gameManagerScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManagerScript.isPlayerDead = true;
        collision.gameObject.GetComponent<Transform>().localPosition = Vector2.zero;
    }
}
