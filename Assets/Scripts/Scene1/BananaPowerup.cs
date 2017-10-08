using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPowerup : MonoBehaviour
{
    public bool touchingGround;
    PlayerMovement player;
    

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }


    void Update()
    {
        if (!touchingGround)
            Destroy(gameObject);

        transform.Translate((-1 * Time.deltaTime), 0f, 0f);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //check to see if it is touching the floor
        if (col.gameObject.tag == "Plank" || col.gameObject.tag == "Floor")
        {
            touchingGround = true;
        }
        else
        {
            touchingGround = false;
        }

        //turn on banana powerup for the player
        if (col.gameObject.tag == "Player")
        {
            player.BananaMethod();
            Destroy(gameObject);
        }
    }
}
