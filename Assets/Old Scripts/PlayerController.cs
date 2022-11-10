using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRigidbody2D;

    public GameManager gameManagerScript;
    public AudioClip jumpSound;

    public float speed;
    public float jumpForce;

    private bool isOnGround;

// Update is called once per frame
    void Update()
    {
        if (isOnGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameManagerScript.coinSound.PlayOneShot(jumpSound);
                playerRigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
       
        if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {

        if(collision.gameObject.name == "Floor")
        {
            isOnGround = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            isOnGround = false;
        }
    }
}
