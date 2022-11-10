using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Cooldown : MonoBehaviour
{
    public float countdown = 2;
    public bool isActive;

    private float actualCountdown;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        actualCountdown = countdown;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isActive = true;
                sr.color = Color.cyan;
            }
        }
        if (isActive)
        {
            if (actualCountdown > 0)
            {
                actualCountdown -= Time.deltaTime;
            }
            else
            {
                isActive = false;
                actualCountdown = countdown;
                sr.color = Color.white;
            }
        }
    }
}
