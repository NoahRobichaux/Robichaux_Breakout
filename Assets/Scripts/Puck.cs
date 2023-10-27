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

    private bool isInSpace;

    private bool isPuckGoingUp;

    private bool hasBrokenOrange = false;
    private bool hasBrokenRed = false;

    public float speed;

    void Start()
    {
        puckRB = GetComponent<Rigidbody2D>();
        speed = 0.5f;
        puck.GetComponent<Transform>().localPosition = new Vector2(0f, -4.2f);
        puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        redBars = GameObject.FindGameObjectsWithTag("RedBars");
        orangeBars = GameObject.FindGameObjectsWithTag("OrangeBars");
        greenBars = GameObject.FindGameObjectsWithTag("GreenBars");
        yellowBars = GameObject.FindGameObjectsWithTag("YellowBars");
    }
    void Update()
    {
        if (isInSpace == false && puck.GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.FreezePosition && Input.GetKeyDown(KeyCode.Space))
        {
            puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            isPuckGoingUp = true;
            float x = Random.Range(-10f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
        }
        if (SaveManager.score == gameManagerScript.maxScore && gameManagerScript.barsBroken == 64)
        {
            puck.GetComponent<Transform>().localPosition = new Vector2(0f, -4.2f);
            if (isInSpace == true)
            {
                puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }
        if (gameManagerScript.barsBroken >= 4 && SaveManager.score < gameManagerScript.maxScore)
        {
            puckRB.AddForce(new Vector2(speed + 0.125f, 0), ForceMode2D.Force);
        }
        if (gameManagerScript.barsBroken >= 12 && SaveManager.score < gameManagerScript.maxScore)
        {
            puckRB.AddForce(new Vector2(speed + 0.125f, 0), ForceMode2D.Force);
        }
        if (hasBrokenOrange && SaveManager.score < gameManagerScript.maxScore)
        {
            puckRB.AddForce(new Vector2(speed+ 0.125f, 0), ForceMode2D.Force);
        }
        if (hasBrokenRed && SaveManager.score <= gameManagerScript.maxScore)
        {
            puckRB.AddForce(new Vector2(speed + 0.125f, 0), ForceMode2D.Force);
        }
        if (gameManagerScript.lives < 3 && gameManagerScript.lives > 0)
        {
            puck.GetComponent<Transform>().localPosition = new Vector2(0f, -4.2f);
            puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            gameManagerScript.playerBar.GetComponent<Transform>().localPosition = new Vector2(0, -4.5f);
            if (Input.GetKeyDown(KeyCode.Space) && puck.GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.FreezePosition)
            {
                puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                isPuckGoingUp = true;
                float x = Random.Range(-10f, 10f);
                float y = 10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Force);

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
            if (isPuckGoingUp == true)
            {
                float x = Random.Range(-10f, 10f);
                float y = 10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Force);
                gameManagerScript.barBreakObject.SetActive(true);
            }
            if (isPuckGoingUp == false)
            {
                float x = Random.Range(-10f, 10f);
                float y = -10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Force);
                gameManagerScript.barBreakObject.SetActive(true);
            }
        }
        if (collision.gameObject.name == "Player_Bar")
        {
            float x = Random.Range(-10f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
            gameManagerScript.barBreakObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedBars")
        {
            SaveManager.score = SaveManager.score + 7;
            gameManagerScript.scoreText.SetText("Score: " + SaveManager.score);
            gameManagerScript.barsBroken = gameManagerScript.barsBroken + 1;
            gameManagerScript.barBreakObject.SetActive(true);
            hasBrokenRed = true;
            isPuckGoingUp = false;
            float x = Random.Range(-10f, 10f);
            float y = -10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "OrangeBars")
        {
            SaveManager.score = SaveManager.score + 5;
            gameManagerScript.scoreText.SetText("Score: " + SaveManager.score);
            gameManagerScript.barsBroken = gameManagerScript.barsBroken + 1;
            gameManagerScript.barBreakObject.SetActive(true);
            hasBrokenOrange = true;
            isPuckGoingUp = false;
            float x = Random.Range(-10f, 10f);
            float y = -10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "GreenBars")
        {
            SaveManager.score = SaveManager.score + 3;
            gameManagerScript.scoreText.SetText("Score: " + SaveManager.score);
            gameManagerScript.barsBroken = gameManagerScript.barsBroken + 1;
            gameManagerScript.barBreakObject.SetActive(true);
            isPuckGoingUp = false;
            float x = Random.Range(-10f, 10f);
            float y = -10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "YellowBars")
        {
            SaveManager.score = SaveManager.score + 1;
            gameManagerScript.scoreText.SetText("Score: " + SaveManager.score);
            gameManagerScript.barsBroken = gameManagerScript.barsBroken + 1;
            gameManagerScript.barBreakObject.SetActive(true);
            isPuckGoingUp = false;
            float x = Random.Range(-10f, 10f);
            float y = -10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
            Destroy(collision.gameObject);
        }
    }
}