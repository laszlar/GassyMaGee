using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Arrays
    private GameObject[] enemyArray;

    //GameObjects
    public GameObject duck;
    public GameObject kettle;
    public GameObject sink;
    public GameObject fatty;
    public GameObject bomb;

    //numerical values
    private float spawnTimer;
    private float chanceTimer;
    private int randomPercent;

    //booleans
    private bool spawnNow;
    private bool spawnedMidTier;

    //Vector2 Positions
    private Vector2 bottomTier;
    private Vector2 midTier;
    private Vector2 topTier;

    //Get player script
    private PlayerMovement playerScript;

    private void Start()
    {
        //find and get player script
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

        //initialize the game object list (or array)
        enemyArray = new GameObject[] { duck, kettle, sink, fatty, bomb };

        //initialize the positions
        bottomTier = new Vector2(5.0f, -0.225f);
        midTier = new Vector2(5.8f, 0.175f);
        topTier = new Vector2(6.6f, 0.675f);

        //initialize booleans
        spawnNow = false;
        spawnedMidTier = false;

        //launch the initial set of enemies
        //this is left in for testing!!!
        for (int x = 0; x < 3; x++)
        {
            if (x == 0)
                Instantiate(enemyArray[Random.Range(0, 2)], bottomTier, Quaternion.identity);

            if (x == 1)
                Instantiate(enemyArray[Random.Range(0, 2)], midTier, Quaternion.identity);

            if (x == 2)
                Instantiate(enemyArray[Random.Range(0, 2)], topTier, Quaternion.identity);
        }
        
    }

    private void Update()
    {
        //start the timer for generating random values
        chanceTimer += Time.deltaTime;       

        if (chanceTimer >= 2.0f)
        {
            randomPercent = Random.Range(0, 9);
            chanceTimer = 0f;
        }

        //start the spawn timer
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 5.0f)
        {
            spawnNow = true;
            spawnTimer = 0f;
        }

        //launch the continual set of enemies, points 1-50
        if (playerScript.points < 50 && spawnNow)
        {
            for (int a = 0; a < 3; a++)
            {
                if (a == 0)
                    Instantiate(enemyArray[Random.Range(0, 2)], bottomTier, Quaternion.identity);

                if (a == 1 && randomPercent >= 5)
                {
                    Instantiate(enemyArray[Random.Range(0, 2)], midTier, Quaternion.identity);
                    spawnedMidTier = true;
                }

                if (a == 2 && spawnedMidTier && randomPercent >= 7)
                {
                    Instantiate(enemyArray[Random.Range(0, 2)], topTier, Quaternion.identity);
                    spawnedMidTier = false;
                }
            }
            //reset this boolean to stop instantiating gameObjects
            spawnNow = false;
        }
    }
}
