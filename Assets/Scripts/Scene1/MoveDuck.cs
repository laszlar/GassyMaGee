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
    public void Update()
    {
        transform.Translate((duckSpeed * Time.deltaTime), 0f, 0f);
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

    void SpeedUp()
    {
        transform.Translate(((duckSpeed * 1.5f) * Time.deltaTime), 0f, 0f);
    }

    void SlowDown()
    {
        halfDuckSpeed = duckSpeed / 2.5f;
        transform.Translate((halfDuckSpeed * Time.deltaTime), 0f, 0f);
    }
}
