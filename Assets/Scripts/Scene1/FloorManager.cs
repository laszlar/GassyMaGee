using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    //arrays for the floor sets!
    public GameObject[] standardSet = new GameObject[4];
    public GameObject[] easySet = new GameObject[4];
    public GameObject[] mediumSet = new GameObject[4];
    public GameObject[] hardSet = new GameObject[4];

    //Vectors for the floor set spawn positions
    private Vector2 originalPOS;
    private Vector2 nextPOS;
    private Vector2 newFloorSetPOS;
    private Vector2 addtlFloorSetPOS;

    //logic for spawning the additional arrays
    public bool spawnedEasy;
    public bool spawnedMedium;
    public bool spawnedHard;

    //player variables
    private GameObject player;
    PlayerMovement playerScript;

    //Floor destoryer access
    private GameObject floorDestroyer;
    FloorBoundaryDestroyer floorDestroyerScript;

    void Start ()
    {
        //set all other bools to false, so that they can spawn
        spawnedEasy = false;
        spawnedMedium = false;
        spawnedHard = false;

        //find player object/shwimps... i mean scripts
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();

        //Find the floor destroyer for the logic
        floorDestroyer = GameObject.Find("FloorBoundaryDestroyer");
        floorDestroyerScript = floorDestroyer.GetComponent<FloorBoundaryDestroyer>();

        //get the vector positions for the inital flooring set
        originalPOS = new Vector2(0f, -0.608f);
        nextPOS = new Vector2(2.2504f, -0.608f);
        newFloorSetPOS = new Vector2(6.7512f, -0.608f);
        addtlFloorSetPOS = new Vector2(9.0016f, -0.608f);

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
	
	//need to check and see if this solves stuff.
	void Update ()
    {
        //adding this in to test git!
        if (floorDestroyerScript.standardIsGone)
        {
            if (!spawnedEasy)
            {
                for (int a = 0; a < 4; a++)
                {
                    //spawn initial easy flooring set when points are 20 or greater
                    if (a == 0)
                    {
                        Instantiate(easySet[Random.Range(0, 3)], newFloorSetPOS, Quaternion.identity);
                    }

                    if (a > 0)
                    {
                        Instantiate(easySet[Random.Range(0, 3)], addtlFloorSetPOS, Quaternion.identity);
                        //add to the X value of the new positions
                        addtlFloorSetPOS.x += 2.2504f;
                    }
                }
                //disable more of the easy set from spawning and reset Vector2 position for next batch.
                addtlFloorSetPOS.x = 9.0016f;
                spawnedEasy = true;
            }
        }
	}
}
