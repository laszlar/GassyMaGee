/*
Moves sink after spawn
!attached to Sink prefab!
*/

using UnityEngine;
using System.Collections;

public class MoveSink : MonoBehaviour
{
    public float sinkSpeed;
    PlayerMovement script;

	// Use this for initialization
	void Start ()
    {
        script = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(sinkSpeed * Time.deltaTime, 0f, 0f);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
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
        transform.Translate(((sinkSpeed * 1.5f) * Time.deltaTime), 0f, 0f);
    }

    void SlowDown()
    {
        transform.Translate(((sinkSpeed * 0.5f) * Time.deltaTime), 0f, 0f);
    }
}
