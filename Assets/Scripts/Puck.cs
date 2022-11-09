using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    private Rigidbody2D puckRB;
    private Vector2 puckDirection;
    
    void Start()
    {
        puckRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float x = Random.Range(-10f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Impulse);
        }
    }
}