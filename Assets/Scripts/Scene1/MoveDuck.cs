/*
Moves ducks at player
!Attached to duck prefab!
*/

using UnityEngine;
using System.Collections;

public class MoveDuck : BaseEnemy
{

    public int duckSpeed;
    public float halfDuckSpeed;
    PlayerMovement script;

    // Use this for initialization
    void Start()
    {
        script = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (script.godMode && coll.gameObject.tag == "Enemy")
        {
                Vector2 target = coll.gameObject.transform.position;
                Vector2 bomb = gameObject.transform.position;
                Vector2 direction = 7f * (target - bomb);

                coll.gameObject.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);  
        }
    }

#region Interface
    public void PaintPower(float fastSpeed)
    {
        base.PaintPower(Speed);
    }

    public void ParachutePower(float slowSpeed)
    {
        base.ParachutePower(Speed);
    }
#endregion
}
