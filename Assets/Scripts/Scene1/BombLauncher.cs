using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncher : MonoBehaviour
{
    float timer = 0f;
    bool launchBombs;
    public GameObject bomb;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if (timer >= 3.0f)
        {
            timer = 0f;
            if (ScoreTracker.score >= 15)
            {
                launchBombs = true;
            }
        }
	}

    void SpawnBombs()
    {
        if (!launchBombs)
            return;

        //Instantiate(bomb, );


    }
}
