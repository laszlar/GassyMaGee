/*
Spawns the planks
!attached to plank prefab!
*/

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

public class PlankSpawner : MonoBehaviour {

    public GameObject plankPrefab;
    //public float xSpawnLocation = 8.177698f;
    //private float ySpawnLoacation = -0.625f;

    private GameObject _rrgWeWalkThePlank;
    private readonly Vector2 _startPosition = new Vector2(0f, -0.6292f);
    private Vector2 _newSpawnPosition;
    private float _offset;
    private float spawnTimer = 0f;
    private bool timerOn;
    private bool ranOnce = true;
    private int timer = 2;

    public static int plankPercent = 100;

    public static List<GameObject> Planks = new List<GameObject>();

    private readonly System.Random _rand = new System.Random(Guid.NewGuid().GetHashCode());

	// Use this for initialization
	void Start ()
	{
		ResetStaticVars ();
	    _offset = plankPrefab.GetComponent<Renderer>().bounds.size.x;
	    _rrgWeWalkThePlank = Instantiate(plankPrefab, _startPosition, Quaternion.identity);
	    _newSpawnPosition = _rrgWeWalkThePlank.transform.position;
        _newSpawnPosition.x += _offset;
        Planks.Add(_rrgWeWalkThePlank);
    }

    void Update()
    {
            Spawn();
    }

    void Spawn ()
	{
        //make sure the coroutine runs once only
        if (ranOnce)
        ShutTimerOffMethod();

        //start the spawn timer
        if (timerOn)
        {
            spawnTimer += Time.deltaTime;
        }

        var isThisPlankMissing = RandomInt();
	    if (Planks.Count < 50)
	    {
	        if (isThisPlankMissing < plankPercent)
	        {
	            _rrgWeWalkThePlank = Instantiate(plankPrefab, _newSpawnPosition, Quaternion.identity);
                //_newSpawnPosition = _rrgWeWalkThePlank.transform.position;

                //spawn objects closer to each other if the timer is greater than 1.1 seconds
                if (spawnTimer >= 1.1f)
                {
                    _newSpawnPosition.x += 0.001f;
                }
                else
                {
                    _newSpawnPosition.x += _offset;
                } 

                //add the game objects to the list
                Planks.Add(_rrgWeWalkThePlank);
	        }
	        else
	        {
	            _newSpawnPosition.x += _offset*2;
	        }
	    }
	}

    private int RandomInt()
    {
        return _rand.Next(0, 100);
    }

	void ResetStaticVars() {
		if (Planks.Count != 0) {
			Planks.Clear ();
		}
		plankPercent = 100;
	}

    //shut the timer off, maybe it causes unecessary cpu resources?
    IEnumerator ShutTimerOff(int timer)
    {
        timerOn = true;
        yield return new WaitForSeconds(timer);
        timerOn = false;
        ranOnce = false;
    }

    private void ShutTimerOffMethod()
    {
        StartCoroutine(ShutTimerOff(timer));
    }
}
