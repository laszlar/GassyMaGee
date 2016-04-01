using UnityEngine;
using System.Collections;

public class PaintLauncher : MonoBehaviour
{
    public float delay;
    public float rate;
    public GameObject Paint;
    public float paintSpawnLocation;


    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);
    }

    void Spawn() //Time to spawn the paint PowerUP!!!!?
    {
        GameObject paintInst = Instantiate(Paint, new Vector2(paintSpawnLocation, Random.Range(-0.7f, 1)), Quaternion.identity) as GameObject;
        paintInst.gameObject.tag = "PowerUp";
    }
}
