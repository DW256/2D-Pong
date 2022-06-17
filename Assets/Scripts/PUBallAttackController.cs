using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBallAttackController : PUTemplateController
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePUBallAttack(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
}
