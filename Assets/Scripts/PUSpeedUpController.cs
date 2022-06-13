using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public Collider2D ball;
    public float magnitude;
    public PowerUpManager manager;

    private float timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > manager.lifeSpan)
        {
            Debug.Log("1 PU Speed Up is gone.");
            manager.RemovePowerUp(gameObject);
        }
    }
}
