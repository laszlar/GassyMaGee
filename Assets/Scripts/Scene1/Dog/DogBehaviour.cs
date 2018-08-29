using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviour : MonoBehaviour
{
    //Player info
    PlayerMovement playerScript;

    //float
    private float travelSpeed = -0.5f;

    //Audio Source!
    private AudioSource source;

	void Start ()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

        //retrieve audio component
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(travelSpeed * Time.deltaTime, 0f, 0f);

        //check for powerups and adjust speed accordingly!
        if (!playerScript.parachuteEnabled && !playerScript.bananaEnabled ||
        playerScript.parachuteEnabled && playerScript.bananaEnabled)
            transform.Translate((travelSpeed * Time.deltaTime), 0f, 0f);

        if (playerScript.bananaEnabled && !playerScript.parachuteEnabled)
        {
            SpeedUp();
        }

        if (playerScript.parachuteEnabled && !playerScript.bananaEnabled)
        {
            SlowDown();
        }
    }

    void SpeedUp()
    {
        transform.Translate(((travelSpeed * 1.5f) * Time.deltaTime), 0f, 0f);
    }

    void SlowDown()
    {
        transform.Translate(((travelSpeed * 0.5f) * Time.deltaTime), 0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerScript.godMode)
            source.Play();
    }
}
