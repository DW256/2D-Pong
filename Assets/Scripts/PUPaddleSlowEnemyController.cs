using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSlowEnemyController : PUTemplateController
{
    public GameObject lPad;
    public GameObject rPad;

    public override void Start()
    {
        base.Start();
        magnitude *= (float)0.1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            if (!ball.GetComponent<BallController>().lastRight)
            {
                if (!manager.activatedPaddleFast[(int)Paddle.Right])
                {
                    rPad.GetComponent<PaddleController>().ActivatePUPaddleFast(magnitude);
                    manager.activatedPaddleFast[(int)Paddle.Right] = true;
                    manager.durationPaddleFast[(int)Paddle.Right] = duration;
                }
            }
            else
            {
                if (!manager.activatedPaddleFast[(int)Paddle.Left])
                {
                    lPad.GetComponent<PaddleController>().ActivatePUPaddleFast(magnitude);
                    manager.activatedPaddleFast[(int)Paddle.Left] = true;
                    manager.durationPaddleFast[(int)Paddle.Left] = duration;
                }
            }

            manager.RemovePowerUp(gameObject);
        }
    }
}
