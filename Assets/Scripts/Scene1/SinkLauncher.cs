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

    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);
    }

    void Spawn() //Time to spawn the ducks!
    {
        Instantiate(sink, new Vector2(6.0f, Random.Range(-0.43f, 2)), Quaternion.identity);
    }
}
