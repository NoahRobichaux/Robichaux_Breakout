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

    private bool hasBrokenOrange = false;
    private bool hasBrokenRed = false;

    public float speed;

    void Start()
    {
        puckRB = GetComponent<Rigidbody2D>();
        speed = 1f;
        puck.GetComponent<Transform>().localPosition = new Vector2(0f, -4.2f);
        puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        redBars = GameObject.FindGameObjectsWithTag("RedBars");
        orangeBars = GameObject.FindGameObjectsWithTag("OrangeBars");
        greenBars = GameObject.FindGameObjectsWithTag("GreenBars");
        yellowBars = GameObject.FindGameObjectsWithTag("YellowBars");
    }
    void Update()
    {
        if (isInSpace == false && gameManagerScript.isPlayerDead == false && puck.GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.FreezePosition && Input.GetKeyDown(KeyCode.Space))
        {
            puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            float x = Random.Range(-10f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
        }
        if (gameManagerScript.score == gameManagerScript.maxScore)
        {
            puck.GetComponent<Transform>().localPosition = new Vector2(0f, -4.2f);
            if (isInSpace == true)
            {
                puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }
        if (gameManagerScript.barsBroken >= 4 && gameManagerScript.score < gameManagerScript.maxScore)
        {
            puckRB.AddForce(new Vector2(speed + 0.25f, 0), ForceMode2D.Force);
        }
        if (gameManagerScript.barsBroken >= 12 && gameManagerScript.score < gameManagerScript.maxScore)
        {
            puckRB.AddForce(new Vector2(speed + 0.25f, 0), ForceMode2D.Force);
        }
        if (hasBrokenOrange && gameManagerScript.score < gameManagerScript.maxScore)
        {
            puckRB.AddForce(new Vector2(speed+ 0.25f, 0), ForceMode2D.Force);
        }
        if (hasBrokenRed && gameManagerScript.score <= gameManagerScript.maxScore)
        {
            puckRB.AddForce(new Vector2(speed + 0.25f, 0), ForceMode2D.Force);
        }
        if (gameManagerScript.isPlayerDead == true && gameManagerScript.lives < 3 && gameManagerScript.lives > 0)
        {
            puck.GetComponent<Transform>().localPosition = new Vector2(0f, -4.2f);
            puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
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
        if (collision.gameObject.tag == "Wall")
        {
            float x = Random.Range(-10f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
        }
        if (collision.gameObject.name == "Player_Bar")
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
            gameManagerScript.barsBroken = gameManagerScript.barsBroken + 1;
            hasBrokenRed = true;
            float x = Random.Range(-10f, 10f);
            float y = -10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "OrangeBars")
        {
            gameManagerScript.score = gameManagerScript.score + 5;
            gameManagerScript.scoreText.SetText("" + gameManagerScript.score);
            gameManagerScript.barsBroken = gameManagerScript.barsBroken + 1;
            hasBrokenOrange= true;
            float x = Random.Range(-10f, 10f);
            float y = -10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "GreenBars")
        {
            gameManagerScript.score = gameManagerScript.score + 3;
            gameManagerScript.scoreText.SetText("" + gameManagerScript.score);
            gameManagerScript.barsBroken = gameManagerScript.barsBroken + 1;
            float x = Random.Range(-10f, 10f);
            float y = -10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "YellowBars")
        {
            gameManagerScript.score = gameManagerScript.score + 1;
            gameManagerScript.scoreText.SetText("" + gameManagerScript.score);
            gameManagerScript.barsBroken = gameManagerScript.barsBroken + 1;
            float x = Random.Range(-10f, 10f);
            float y = -10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
    }
}