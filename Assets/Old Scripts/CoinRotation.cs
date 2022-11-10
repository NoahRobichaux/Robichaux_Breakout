using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public GameManager gameManagerScript;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.3f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManagerScript.coinTotal++;
        gameManagerScript.coinSound.Play();
        ps.Emit(10);
        Destroy(gameObject);
    }
}
