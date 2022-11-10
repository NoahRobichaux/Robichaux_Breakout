using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoomTimer))]
public class Mine : MonoBehaviour
{
    private BoomTimer boomTimerScript;
    // Start is called before the first frame update
    void Start()
    {
        boomTimerScript = GetComponent<BoomTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
