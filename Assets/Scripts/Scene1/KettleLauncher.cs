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
        playerPos.x = player.transform.position.x;      //get the player's position

        kettleSpawnLocation = playerPos.x + offset;     //add an offset to Player's position
    }

    void Spawn() //Time to spawn the ducks!
    {
        Instantiate(kettle, new Vector2(kettleSpawnLocation, Random.Range(-0.47f, 2)), Quaternion.identity);
    }
}
