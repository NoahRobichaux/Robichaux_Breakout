using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer_Kill : MonoBehaviour
{
    public float countdown;
    public TMP_Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        countdownText.SetText("" + Mathf.Ceil(countdown));
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
