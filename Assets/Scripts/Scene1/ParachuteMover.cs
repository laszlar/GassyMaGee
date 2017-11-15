/*
Moves the parachute
!attached to the parachute prefab!
*/

using UnityEngine;
using System.Collections;

public class ParachuteMover : MonoBehaviour
{

    private float slowSpeed = -0.5f;
    private float normalSpeed = -1.0f;
    private float fastSpeed = -1.5f;
    PlayerMovement playerScript;
    private SpriteRenderer render;

    public AudioSource source;
    private float audioTimer;

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        source = GetComponent<AudioSource>();
        render = GetComponent<SpriteRenderer>();
    }

    //move that Parachute!
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.ParachuteMethod();
            render.enabled = false;
            source.Play();

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

