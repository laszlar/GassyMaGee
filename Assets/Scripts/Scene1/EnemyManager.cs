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
    private bool spawnedMidTierException;

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
        spawnedMidTierException = false;

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

        NoviceEnemies();
        DifficultEnemies();
    }

    #region StartNoviceEnemies
    private void NoviceEnemies()
    {
        //launch the continual set of enemies, points 1-25
        if (playerScript.points < 25 && spawnNow)
        {
            for (int a = 0; a < 3; a++)
            {
                //launch the bottom enemy
                if (a == 0)
                    Instantiate(enemyArray[Random.Range(0, 2)], bottomTier, Quaternion.identity);

                //launch second enemy 50% of time, make an exception 10% of times to not spawn
                if (a == 1 && randomPercent >= 5)
                {
                    if (randomPercent == 7)
                    {
                        spawnedMidTierException = true;
                    }
                    else
                    {
                        Instantiate(enemyArray[Random.Range(0, 2)], midTier, Quaternion.identity);
                        spawnedMidTier = true;
                    }
                }

                //spawn the top enemy 20% of the time
                if (a == 2 && spawnedMidTier && randomPercent >= 7)
                {
                    Instantiate(enemyArray[Random.Range(0, 2)], topTier, Quaternion.identity);
                    spawnedMidTier = false;
                }

                //spawn the top enemy 10% of the time without the second enemy below him
                if (a == 2 && spawnedMidTierException)
                {
                    Instantiate(enemyArray[Random.Range(0, 2)], topTier, Quaternion.identity);
                    spawnedMidTierException = false;
                }
            }
            //reset this boolean to stop instantiating gameObjects
            spawnNow = false;
        }
    }
    #endregion

    #region DifficultEnemies
    private void DifficultEnemies()
    {
        //launch the continual set of enemies, points 1-25
        if (playerScript.points >= 25 && spawnNow)
        {
            for (int a = 0; a < 3; a++)
            {
                //launch the bottom enemy
                if (a == 0)
                    Instantiate(enemyArray[Random.Range(0, 4)], bottomTier, Quaternion.identity);

                //launch second enemy 50% of time, make an exception 10% of times to not spawn
                if (a == 1 && randomPercent >= 5)
                {
                    if (randomPercent == 7)
                    {
                        spawnedMidTierException = true;
                    }
                    else
                    {
                        Instantiate(enemyArray[Random.Range(0, 4)], midTier, Quaternion.identity);
                        spawnedMidTier = true;
                    }
                }

                //spawn the top enemy 20% of the time
                if (a == 2 && spawnedMidTier && randomPercent >= 7)
                {
                    Instantiate(enemyArray[Random.Range(0, 4)], topTier, Quaternion.identity);
                    spawnedMidTier = false;
                }

                //spawn the top enemy 10% of the time without the second enemy below him
                if (a == 2 && spawnedMidTierException)
                {
                    Instantiate(enemyArray[Random.Range(0, 4)], topTier, Quaternion.identity);
                    spawnedMidTierException = false;
                }
            }
            //reset this boolean to stop instantiating gameObjects
            spawnNow = false;
        }
    }
    #endregion
}
