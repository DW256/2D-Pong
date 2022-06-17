using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUTemplateController : MonoBehaviour
{
    public Collider2D ball;
    public float magnitude;
    public PowerUpManager manager;
    public int lifeSpan;
    public int duration;

    protected float timer;
    // Start is called before the first frame update
    public virtual void Start()
    {
        lifeSpan = lifeSpan is 0 ? manager.lifeSpan : lifeSpan; //if 0 use value from manager
    }

    // Update is called once per frame
    public virtual void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeSpan)
        {
            Debug.Log("1 PU is gone.");
            manager.RemovePowerUp(gameObject);
        }
    }

}
