/*
Spawns the Kettles
!Attached to Kettle launcher prefab!
*/

using UnityEngine;
using System.Collections;

public class KettleLauncher : MonoBehaviour
{
    public float delay = 30f;
    public float rate = 20f;
    public float offset = 5f;
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
        Instantiate(kettle, new Vector2(kettleSpawnLocation, Random.Range(-0.7f, 1)), Quaternion.identity);
    }
}
