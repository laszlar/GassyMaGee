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

    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);
    }

    void Spawn() //Time to spawn the ducks!
    {
        Instantiate(kettle, new Vector2(6.0f, Random.Range(-0.47f, 2)), Quaternion.identity);
    }
}
