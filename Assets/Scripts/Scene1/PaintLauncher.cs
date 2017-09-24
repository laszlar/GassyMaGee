/*
Spawns the paint powerup
!attached to paint launcher!
*/

using UnityEngine;
using System.Collections;

public class PaintLauncher : MonoBehaviour
{
    public float delay;
    public float rate;
    public float offset;
    public GameObject Paint;
    public GameObject player;
    float paintSpawnLocation;
    Vector2 playerPos;
    Vector3 launch;


    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);

        player = GameObject.Find("Player");
    }

    void Update()
    {
        playerPos.x = player.transform.position.x;

        paintSpawnLocation = playerPos.x + offset;


        
    }
    void Spawn() //Time to spawn the paint PowerUP
    {
        Instantiate(Paint, new Vector3(paintSpawnLocation, Random.Range(-0.55f, 1.5f)), Quaternion.identity);
    }
}
