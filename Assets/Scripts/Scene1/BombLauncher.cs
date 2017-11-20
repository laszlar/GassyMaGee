using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncher : MonoBehaviour
{
    float timer = 0f;
    int offset = 5;
    bool launchBombs;
    public GameObject bomb;
    public GameObject player;

    Vector2 pos;
    float yValue;

	// Use this for initialization
	void Start ()
    {
        //Move that bomb! Featuring Ty Pennington!!!
        InvokeRepeating("SpawnBombs", 0f, 8f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        //created a timer to check the score ever 3 seconds
        if (timer >= 3.0f)
        {
            timer = 0f;
            if (ScoreTracker.score >= 0)
            {
                launchBombs = true;
            }
        }
        //pos = transform.position;
        //manipulate the position of the bomb launcher
        transform.position = new Vector2(6.0f, Random.Range(-0.5f, 1.5f));
        pos = transform.position;
	}

    void SpawnBombs()
    {
        //if the score isn't greater than 15
        if (!launchBombs)
            return;

        //Spawn that bomb!
        Instantiate(bomb, pos, Quaternion.identity);
    }
}
