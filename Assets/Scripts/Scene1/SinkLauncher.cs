/*
Spawns the sinks.
!attached to sink launcher!
*/

using UnityEngine;
using System.Collections;

public class SinkLauncher : MonoBehaviour
{
    public float delay;
    public float rate;
    public float offset;
    public GameObject sink;
    public GameObject player;
    float sinkSpawnLocation;
    Vector2 playerPos;


    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);
    }

    void Update()
    {
        playerPos.x = player.transform.position.x;

        sinkSpawnLocation = playerPos.x + offset;
    }

    void Spawn() //Time to spawn the ducks!
    {
        Instantiate(sink, new Vector2(sinkSpawnLocation, Random.Range(-0.7f, 1)), Quaternion.identity);
    }
}
