using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juicy : MonoBehaviour
{
    private SpriteRenderer sr;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        sr.color = Random.ColorHSV(0,1,1,1,0.5f,1);
        collision.gameObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 1, 1, 0.5f, 1);
        var main = ps.main;
        main.startColor = Random.ColorHSV(0, 1, 1, 1, 0.5f, 1);
        ps.Emit(30);
    }
}
