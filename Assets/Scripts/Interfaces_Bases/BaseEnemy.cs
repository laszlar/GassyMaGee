using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IPowerUp {

    private float speed = -1.0f; 

	public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public virtual void Update ()
    {
        transform.Translate((speed * Time.deltaTime), 0f, 0f);
    }

    public virtual void BananaPower(float fastSpeed)
    {
        this.speed = fastSpeed;
    }

    public virtual void ParachutePower(float slowSpeed)
    {
        this.speed = slowSpeed;
    }

}
