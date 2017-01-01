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

    void OnTriggerEnter2D(Collider2D col)
    {

        //this isn't working as we speak
        if (col.gameObject.tag == "Plank")
        {
            touchingGround = true;
        }
        else
        {
            touchingGround = false;
        }

        if (!touchingGround)
            Destroy(gameObject);

        //this is working however
        if (col.gameObject.tag == "Player")
        {
            player.BananaMethod();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collider2D col)
    {
        
    }
}
