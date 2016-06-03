using UnityEngine;
using System.Collections;

public class PlankSpawner : MonoBehaviour {

    public GameObject plankPrefab;
    public float respawnRate = 0.1f;
    public float iniRespawnTime = 0.1f;
    public float xSpawnLocation = 4.0f;
    public float ySpawnLoacation = 0.8f;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Spawn", iniRespawnTime, respawnRate);

	}
	
	void Spawn ()
    {
        Instantiate(plankPrefab, new Vector2(xSpawnLocation, ySpawnLoacation), Quaternion.identity);
    }
}
