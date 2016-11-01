/*
Spawns the ducks
!Attached to duck launcher prefab!
*/

using UnityEngine;
using System.Collections;

public class DuckLauncher : MonoBehaviour
{

    public float delay;
    public float rate;
    public float offset;
    float duckSpawnLocation;
    public GameObject duck;
    public GameObject player;
    Vector2 playerPos;


	void Start ()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);

        player = GameObject.Find("Player");
    }

    void Update ()
    {
        playerPos.x = player.transform.position.x;

        duckSpawnLocation = playerPos.x + offset;
    }
	
	void Spawn () //Time to spawn the ducks!
    {
        Instantiate(duck, new Vector2(duckSpawnLocation, Random.Range(-0.7f, 1)), Quaternion.identity);
	} 
}
