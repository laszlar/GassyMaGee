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

    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);
    }

    void Spawn() //Time to spawn the paint PowerUP
    {
        Instantiate(Parachute, new Vector2(6.0f, Random.Range(-0.4f, 2f)), Quaternion.identity);
    }
}
