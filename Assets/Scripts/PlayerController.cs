using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
