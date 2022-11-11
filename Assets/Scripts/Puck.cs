using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puck : MonoBehaviour
{
    private Rigidbody2D puckRB;
    private Vector2 puckDirection;
    public GameObject puck;
    private RigidbodyType2D rbt;

    public bool isInSpace;

    void Start()
    {
        puckRB = GetComponent<Rigidbody2D>();
        rbt = RigidbodyType2D.Static;
    }
    void Update()
    {
        if (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rbt = RigidbodyType2D.Dynamic;
                float x = Random.Range(-10f, 10f);
                float y = 10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
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
    }
}