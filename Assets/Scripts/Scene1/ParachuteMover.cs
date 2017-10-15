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

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
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
            Destroy(gameObject);
            playerScript.ParachuteMethod();
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

