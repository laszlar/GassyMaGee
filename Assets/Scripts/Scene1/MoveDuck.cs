/*
Moves ducks at player
!Attached to duck prefab!
*/

using UnityEngine;
using System.Collections;

public class MoveDuck : MonoBehaviour
{
    private float moveSpeed = -1.0f;
    private float slowSpeed = -0.5f;
    private float fastSpeed = -1.5f;

    PlayerMovement playerScript;

    //audio
    private AudioSource source;

    // Use this for initialization
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

        //retrieve audio compnonent
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        //If neither banana or parachute is active duck moves at regular speed.
        if (!playerScript.parachuteEnabled && !playerScript.bananaEnabled ||
            playerScript.parachuteEnabled && playerScript.bananaEnabled)
            transform.Translate((moveSpeed * Time.deltaTime), 0f, 0f);

        if (playerScript.bananaEnabled && !playerScript.parachuteEnabled)
        {
            SpeedUp();
        }

        if (playerScript.parachuteEnabled && !playerScript.bananaEnabled)
        {
            SlowDown();
        }
    }

    

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (playerScript.godMode && coll.gameObject.tag == "Enemy")
        {
                Vector2 target = coll.gameObject.transform.position;
                Vector2 bomb = gameObject.transform.position;
                Vector2 direction = 7f * (target - bomb);

                coll.gameObject.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);  
        }

        if (coll.gameObject.tag == "Player" && playerScript.godMode)
            source.Play();
    }

    void SpeedUp()
    {
        transform.Translate((fastSpeed * Time.deltaTime), 0f, 0f);
    }

    void SlowDown()
    {
        transform.Translate((slowSpeed * Time.deltaTime), 0f, 0f);
    }
}
