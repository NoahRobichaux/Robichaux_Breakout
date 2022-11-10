using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float camelCase;

    private bool changeDirection = false;

    public float rotateObjectX;

    public float rotateObjectY;

    public float scaleObjectX;

    public float scaleObjectY;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.x >= 9.7f)
        {
            camelCase = -camelCase;
        }else if(this.transform.position.x <= -9.7f)
        {
            camelCase = -camelCase;
        }
        
        this.transform.Translate(camelCase, 0, 0);

        this.transform.Rotate(rotateObjectX, rotateObjectY, 0);

        this.transform.localScale += new Vector3(scaleObjectX, scaleObjectY, 0);
    }
}
