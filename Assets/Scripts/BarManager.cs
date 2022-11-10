using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarManager : MonoBehaviour
{

    public GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedBars")
        {
            gameManagerScript.scoreText.SetText("" + 7);
        }
        if (collision.gameObject.tag == "OrangeBars")
        {
            gameManagerScript.scoreText.SetText("" + 5);
        }
        if (collision.gameObject.tag == "GreenBars")
        {
            gameManagerScript.scoreText.SetText("" + 3);
        }
        if (collision.gameObject.tag == "YellowBars")
        {
            gameManagerScript.scoreText.SetText("" + 1);
        }
        Destroy(gameObject);
    }
}
