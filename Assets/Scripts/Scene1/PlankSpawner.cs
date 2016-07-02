using UnityEngine;
using System.Collections;

public class PlankSpawner : MonoBehaviour {

    public GameObject plankPrefab;
    public GameObject player;
    Vector2 playerPos;
    public float offset;
    public float respawnRate = 0.1f;
    public float iniRespawnTime = 0.1f;
    public float xSpawnLocation;
    public float ySpawnLoacation = 0.8f;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Spawn", iniRespawnTime, respawnRate);
	}

    void Update()
    {
        playerPos.x = player.transform.position.x;

        xSpawnLocation = playerPos.x + offset;
    }
	
	void Spawn ()
    {
        Instantiate(plankPrefab, new Vector2(xSpawnLocation, ySpawnLoacation), Quaternion.identity);
    }
}
