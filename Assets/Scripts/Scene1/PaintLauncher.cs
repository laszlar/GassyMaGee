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


    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);
    }

    void Update()
    {
        playerPos.x = player.transform.position.x;

        paintSpawnLocation = playerPos.x + offset;
    }
    void Spawn() //Time to spawn the paint PowerUP
    {
        Instantiate(Paint, new Vector2(paintSpawnLocation, Random.Range(-0.7f, 1)), Quaternion.identity);
    }
}
