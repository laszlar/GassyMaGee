using UnityEngine;
using System.Collections;

public class ParachuteLauncher : MonoBehaviour
{
    public float delay;
    public float rate;
    public GameObject Parachute;
    public float parachuteSpawnLocation;

    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);
    }

    void Spawn() //Time to spawn the paint PowerUP
    {
        Instantiate(Parachute, new Vector2(parachuteSpawnLocation, Random.Range(-0.3f, 1.15f)), Quaternion.identity);
    }
}
