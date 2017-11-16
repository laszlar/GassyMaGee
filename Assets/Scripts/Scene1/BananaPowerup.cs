using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPowerup : MonoBehaviour
{
    //variables of the speed of the banana!
    private float slowSpeed = -0.5f;
    private float normalSpeed = -1.0f;
    private float fastSpeed = -1.5f;

    private bool touchingGround;
    PlayerMovement playerScript;

    private SpriteRenderer render;

    public AudioSource source;
    private float audioTimer = 0f;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        render = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }


    void Update()
    {
        //if no powerups or if both powerups are active then run at regular speed!
        if (!playerScript.parachuteEnabled && !playerScript.bananaEnabled ||
            playerScript.parachuteEnabled && playerScript.bananaEnabled)
        {
            transform.Translate((normalSpeed * Time.deltaTime), 0f, 0f);
        }

        //check for powerups
        if (playerScript.bananaEnabled && !playerScript.parachuteEnabled)
        {
            SpeedUp();
        }

        if (playerScript.parachuteEnabled && !playerScript.bananaEnabled)
        {
            SlowDown();
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //turn on banana powerup for the player
        if (col.gameObject.tag == "Player")
        {
            playerScript.BananaMethod();
            source.Play();
            render.enabled = false;

            audioTimer += Time.deltaTime;
            if (audioTimer >= 0.3f)
            {
                Destroy(gameObject);
            }
            
        }
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
