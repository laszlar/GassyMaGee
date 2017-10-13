using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThatBus : MonoBehaviour
{
    private float speed = -1.0f;

    PlayerMovement playerScript;

	// Use this for initialization
	void Start ()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if no powerups or if both powerups are active then run at regular speed!
        if (!playerScript.parachuteEnabled && !playerScript.bananaEnabled ||
            playerScript.parachuteEnabled && playerScript.bananaEnabled)
        {
            transform.Translate((speed * Time.deltaTime), 0f, 0f);
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

    void SpeedUp()
    {
        transform.Translate(((speed * 1.5f) * Time.deltaTime), 0f, 0f);
    }

    void SlowDown()
    {
        transform.Translate(((speed * 0.5f) * Time.deltaTime), 0f, 0f);
    }
}
