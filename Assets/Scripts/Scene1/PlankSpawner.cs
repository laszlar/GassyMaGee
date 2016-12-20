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
    private readonly Vector2 _startPosition = new Vector2(8.177698f, -0.625f);
    private Vector2 _newSpawnPosition;
    private float _offset;

    public static int plankPercent = 100;

    public static List<GameObject> Planks = new List<GameObject>();

    private readonly System.Random _rand = new System.Random(Guid.NewGuid().GetHashCode());

	// Use this for initialization
	void Start ()
	{
	    _offset = plankPrefab.GetComponent<Renderer>().bounds.size.x;
	    _rrgWeWalkThePlank = Instantiate(plankPrefab, _startPosition, Quaternion.identity);
	    _newSpawnPosition = _rrgWeWalkThePlank.transform.position;
	    _newSpawnPosition.x += _offset;
        Planks.Add(_rrgWeWalkThePlank);
    }

    void Update()
    {
        Debug.Log(Planks.Count);
            Spawn();
    }
	
	void Spawn ()
	{
        var isThisPlankMissing = RandomInt();
        //Debug.Log(isThisPlankMissing);
	    if (Planks.Count < 100)
	    {
	        if (isThisPlankMissing < plankPercent)
	        {
	            _rrgWeWalkThePlank = Instantiate(plankPrefab, _newSpawnPosition, Quaternion.identity);
                _newSpawnPosition = _rrgWeWalkThePlank.transform.position;
	            _newSpawnPosition.x += _offset;
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
}
