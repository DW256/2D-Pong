using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public float speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;

    private Vector3 initialSize;
    private float initialSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSize = gameObject.transform.localScale;
        initialSpeed = speed;
    }

    // Update is called once per frame
    private void Update()
    {
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey)) //paddle up
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey)) //paddle down
        {
            return Vector2.down * speed;
        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        //Debug.Log("TEST: " + movement);
        rig.velocity = movement;
    }

    public void ActivatePUPaddleLong(float magnitude)
    {
        gameObject.transform.localScale = new Vector3(initialSize.x, initialSize.y * magnitude, initialSize.z);
    }
    
    public void DeactivatePUPaddleLong()
    {
        gameObject.transform.localScale = initialSize;
    }

    public void ActivatePUPaddleFast(float magnitude)
    {
        speed *= magnitude;
    }

    public void DeactivatePUPaddleFast()
    {
        speed = initialSpeed;
    }

}
