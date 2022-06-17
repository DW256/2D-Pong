using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;
    public bool lastRight=false;

    private Rigidbody2D rig;
    private float maxVelocity = 8;

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    void OnCollisionExit2D(Collision2D paddle)
    {
        if (paddle.gameObject.name == "Paddle R") //last touched paddle = Paddle R
        {
            lastRight = true;
            Debug.Log("Right");
        }
        else if(paddle.gameObject.name == "Paddle L")
        {
            lastRight = false;
            Debug.Log("Left");
        }
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);

        if (rig.velocity.x < 0)
        {
            rig.velocity = new Vector2(speed.x * -1, speed.y);
        }
        else if (rig.velocity.x > 0)
        {
            rig.velocity = new Vector2(speed.x * 1, speed.y);
        }
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }

    public void ActivatePUBallAttack(float magnitude)
    {
        rig.velocity = new Vector2(rig.velocity.x * magnitude, rig.velocity.y);
    }

    public void ActivatePUBallBlocker(float magnitude)
    {
        rig.velocity = new Vector2(rig.velocity.x * -magnitude, rig.velocity.y);
    }

    private void Update()
    {
        Debug.Log(rig.velocity);
        if (rig.velocity == new Vector2(0, 0)) ResetBall();
        rig.velocity = Vector2.ClampMagnitude(rig.velocity,maxVelocity);
    }
}
