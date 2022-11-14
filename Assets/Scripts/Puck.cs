using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puck : MonoBehaviour
{
    private Rigidbody2D puckRB;
    private Vector2 puckDirection;
    public GameObject puck;

    private GameObject[] redBars;
    private GameObject[] orangeBars;
    private GameObject[] greenBars;
    private GameObject[] yellowBars;

    public GameManager gameManagerScript;

    public bool isInSpace;

    void Start()
    {
        puckRB = GetComponent<Rigidbody2D>();
        puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        isInSpace= true;

        redBars = GameObject.FindGameObjectsWithTag("RedBars");
        orangeBars = GameObject.FindGameObjectsWithTag("OrangeBars");
        greenBars = GameObject.FindGameObjectsWithTag("GreenBars");
        yellowBars = GameObject.FindGameObjectsWithTag("YellowBars");
    }
    void Update()
    {
        if (isInSpace == true)
        {
            if (puck.GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.FreezePosition && gameManagerScript.bGMGameObject == isActiveAndEnabled && gameManagerScript.isPlayerDead == false)
            {
                puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                float x = Random.Range(-10f, 10f);
                float y = 10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
            }
        }
        if (gameManagerScript.isPuckOnWinWall && gameManagerScript.score < gameManagerScript.maxScore)
        {
            puck.GetComponent<Transform>().localPosition = Vector2.zero;
            if (isInSpace == true)
            {
                puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }
        if (gameManagerScript.score == gameManagerScript.maxScore)
        {
            puck.GetComponent<Transform>().localPosition = Vector2.zero;
            if (isInSpace == true)
            {
                puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player_Bar")
        {
            isInSpace = false;
        }
        if (collision.gameObject.tag == "Wall")
        {
            isInSpace = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player_Bar")
        {
            isInSpace = true;
        }
        if (collision.gameObject.tag == "Wall")
        {
            isInSpace = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" && isInSpace == false)
        {
            float x = Random.Range(-10f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
        }
        if (collision.gameObject.name == "Player_Bar" && isInSpace == false)
        {
            float x = Random.Range(-10f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedBars")
        {
            gameManagerScript.score = gameManagerScript.score + 7;
            gameManagerScript.scoreText.SetText("" + gameManagerScript.score);
            float x = Random.Range(-10f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "OrangeBars")
        {
            gameManagerScript.score = gameManagerScript.score + 5;
            gameManagerScript.scoreText.SetText("" + gameManagerScript.score);
            float x = Random.Range(-10f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "GreenBars")
        {
            gameManagerScript.score = gameManagerScript.score + 3;
            gameManagerScript.scoreText.SetText("" + gameManagerScript.score);
            float x = Random.Range(-10f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "YellowBars")
        {
            gameManagerScript.score = gameManagerScript.score + 1;
            gameManagerScript.scoreText.SetText("" + gameManagerScript.score);
            float x = Random.Range(-10f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
    }
}