using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomTimer : MonoBehaviour
{
    public float countdown;
    public bool isTimeUp;

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        if (countdown <= 0)
        {
            isTimeUp = true;
        }
    }
}
