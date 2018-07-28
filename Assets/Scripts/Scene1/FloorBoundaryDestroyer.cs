using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBoundaryDestroyer : MonoBehaviour
{
    //Get player info (points/scoring)
    private GameObject player;
    private PlayerMovement playerScript;

    //logic operators for destroying specific floor sets
    private bool destroyStandard;
    private bool destroyEasy;
    private bool destroyMedium;

    //flags to let FloorManager class know to spawn new flooring sets
    public bool standardIsGone;
    public bool easyIsGone;
    public bool mediumIsGone;

	// Use this for initialization
	void Start ()
    {
        //find player and PlayerMovement script
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();

        //setting some bools to false on start up
        standardIsGone = false;
        easyIsGone = false;
        mediumIsGone = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Depending on the points, set true to destroy the flooring specific flooring sets
        if (playerScript.points > 25)
        {
            destroyStandard = true;
        }

        if (playerScript.points > 55)
        {
            destroyEasy = true;
        }

        if (playerScript.points > 85)
        {
            destroyMedium = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (destroyStandard)
        {
            if (collision.gameObject.transform.parent.name == "PlankSet_Standard(Clone)")
            {
                standardIsGone = true;
                Destroy(collision.transform.parent.gameObject); 
            }
        }

        if (destroyEasy)
        {
            if (collision.gameObject.transform.parent.name == "PlankSet_Easy1(Clone)" ||
                collision.gameObject.transform.parent.name == "PlankSet_Easy2(Clone)" ||
                collision.gameObject.transform.parent.name == "PlankSet_Easy3(Clone)" ||
                collision.gameObject.transform.parent.name == "PlankSet_Easy4(Clone)")
            {
                easyIsGone = true;
                Destroy(collision.transform.parent.gameObject);
            }
        }

        if (destroyMedium)
        {
            if (collision.gameObject.transform.parent.name == "PlankSet_Medium1(Clone)" ||
                collision.gameObject.transform.parent.name == "PlankSet_Medium2(Clone)" ||
                collision.gameObject.transform.parent.name == "PlankSet_Medium3(Clone)" ||
                collision.gameObject.transform.parent.name == "PlankSet_Medium4(Clone)")
            {
                mediumIsGone = true;
                Destroy(collision.transform.parent.gameObject);
            }
        }
    }
}
