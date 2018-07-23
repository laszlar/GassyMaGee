using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject[] standardSet = new GameObject[4];
    public GameObject[] easySet = new GameObject[4];
    public GameObject[] mediumSet = new GameObject[4];
    public GameObject[] hardSet = new GameObject[4];
    private Vector2 originalPOS;
    private Vector2 nextPOS;

    //player variables
    private GameObject player;
    PlayerMovement playerScript;

    // Use this for initialization
    void Start ()
    {
        //find player object/shwimps... i mean scripts
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();

        //get the vector positions for the inital flooring set
        originalPOS = new Vector2(0f, -0.608f);
        nextPOS = new Vector2(2.2504f, -0.608f);

        //Instantiate game objects in array at start up
        for(int i = 0; i < 4; i++)
        {
            //Spawn the first set of planks at the original position
            if (i == 0)
            {
                Instantiate(standardSet[i], originalPOS, Quaternion.identity);
            }

            //spawn the remaining sets at their new positions!
            if (i > 0)
            {
                Instantiate(standardSet[i], nextPOS, Quaternion.identity);
                //add to the X value of the new positions
                nextPOS.x += 2.2504f;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if(playerscript.points)
	}
}
