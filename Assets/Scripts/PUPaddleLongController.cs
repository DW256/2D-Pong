using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleLongController : PUTemplateController
{
    public GameObject lPad;
    public GameObject rPad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            if (ball.GetComponent<BallController>().lastRight)
            {
                if (!manager.activatedPaddleLong[(int)Paddle.Right])
                {
                    rPad.GetComponent<PaddleController>().ActivatePUPaddleLong(magnitude);
                    manager.activatedPaddleLong[(int)Paddle.Right] = true;
                    manager.durationPaddleLong[(int)Paddle.Right] = duration;
                    Debug.Log(manager.durationPaddleLong[(int)Paddle.Right]);
                }
            }
            else
            {
                if (!manager.activatedPaddleLong[(int)Paddle.Left])
                {
                    lPad.GetComponent<PaddleController>().ActivatePUPaddleLong(magnitude);
                    manager.activatedPaddleLong[(int)Paddle.Left] = true;
                    manager.durationPaddleLong[(int)Paddle.Left] = duration;
                    Debug.Log(manager.durationPaddleLong[(int)Paddle.Left]);
                }
            }

            manager.RemovePowerUp(gameObject);
        }
    }
}
