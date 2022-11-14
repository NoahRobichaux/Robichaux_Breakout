using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puck : MonoBehaviour
{
    private Rigidbody2D puckRB;
    private Vector2 puckDirection;
    public GameObject puck;
    
    public GameManager gameManagerScript;

    public bool isInSpace;

    void Start()
    {
        puckRB = GetComponent<Rigidbody2D>();
        puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }
    void Update()
    {
        if (isInSpace == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                float x = Random.Range(-10f, 10f);
                float y = 10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
            }
            if (puck.GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.FreezePosition && Time.timeScale == 1 && gameManagerScript.isPlayerDead == false)
            {
                puck.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInSpace = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
        if (collision.gameObject.tag == "Player")
        {
            float x = Random.Range(-10f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
        }
    }
}