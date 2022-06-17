using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBallBlockerController : PUTemplateController
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePUBallBlocker(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
}
