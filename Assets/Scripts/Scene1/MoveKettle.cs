/*
Moves kettle after spawn.
!attached to kettle prefab!
*/

using UnityEngine;
using System.Collections;

public class MoveKettle : MonoBehaviour {

    public float kettleSpeed;
    PlayerMovement script;
    
    // Use this for initialization
	void Start ()
    {
        script = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(kettleSpeed * Time.deltaTime, 0f, 0f);          //if player hits parachute power up, 
    }


    void OnCollisionEnter2D(Collision2D coll)                       //if player hits paint canister, turn player into god mode,
    {                                                               //and object goes flying when player hits them.
        if (script.godMode && coll.gameObject.tag == "Enemy") 
        {
            Vector2 target = coll.gameObject.transform.position;
            Vector2 bomb = gameObject.transform.position;
            Vector2 direction = 7f * (target - bomb);

            coll.gameObject.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
        }
    }

    void SpeedUp()
    {
        transform.Translate(((kettleSpeed * 1.5f) * Time.deltaTime), 0f, 0f);
    }

    void SlowDown()
    {
        transform.Translate(((kettleSpeed * 0.5f) * Time.deltaTime), 0f, 0f);
    }
}
