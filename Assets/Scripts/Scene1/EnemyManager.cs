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
    private float timer;
    private int percentChance;

    //Vector2 Positions
    private Vector2 bottomTier;
    private Vector2 midTier;
    private Vector2 topTier;

    private void Start()
    {
        //initialize the game object list (or array)
        enemyArray = new GameObject[] { duck, kettle, sink, fatty, bomb };

        //initialize the positions
        bottomTier = new Vector2(5.0f, -0.4f);
        midTier = new Vector2(5.8f, 0.1f);
        topTier = new Vector2(6.6f, 0.6f);

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
        timer += Time.deltaTime;       
    }
}
