using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRigidbody2D;

    public GameManager gameManagerScript;

    public float speed;

// Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
        }
    }
    void RightButtonPress()
    {
        playerRigidbody2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
    }
    void LeftButtonPress()
    {
        playerRigidbody2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
    }
}
