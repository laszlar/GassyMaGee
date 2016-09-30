/*
Spawns the parachute powerup
!attached to the parachute launcher!
*/

using UnityEngine;
using System.Collections;

public class ParachuteLauncher : MonoBehaviour
{
    public float delay;
    public float rate;
    public float offset;
    public GameObject Parachute;
    public GameObject player;
    float parachuteSpawnLocation;
    Vector2 playerPos;

    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);
    }

    void Update()
    {
        playerPos.x = player.transform.position.x;

        parachuteSpawnLocation = playerPos.x + offset;
    }

    void Spawn() //Time to spawn the paint PowerUP
    {
        Instantiate(Parachute, new Vector2(parachuteSpawnLocation, Random.Range(-0.3f, 1.15f)), Quaternion.identity);
    }
}
