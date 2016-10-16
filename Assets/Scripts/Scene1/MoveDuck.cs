/*
Moves ducks at player
!Attached to duck prefab!
*/

using UnityEngine;
using System.Collections;

public class MoveDuck : MonoBehaviour
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
    void Update()
    {
        if (!script.duckThing)                                              //in regards to the parachute powerup, if no powerup
        {
            transform.Translate(duckSpeed * Time.deltaTime, 0f, 0f);
        }
        else                                                                //if parachute powerup is activated
        {
            transform.Translate(halfDuckSpeed * Time.deltaTime, 0f, 0f);
        }
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
}
