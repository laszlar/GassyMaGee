/*
Spawns the Kettles
!Attached to Kettle launcher prefab!
*/

using UnityEngine;
using System.Collections;

public class KettleLauncher : MonoBehaviour
{
    public float delay;
    public float rate;
    public float offset;
    public GameObject kettle;
    public GameObject player;
    float kettleSpawnLocation;
    Vector2 playerPos;

    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);
    }

    void Update()
    {
        playerPos.x = player.transform.position.x;

        kettleSpawnLocation = playerPos.x + offset;
    }

    void Spawn() //Time to spawn the ducks!
    {
        Instantiate(kettle, new Vector2(kettleSpawnLocation, Random.Range(-0.7f, 1)), Quaternion.identity);
    }
}
