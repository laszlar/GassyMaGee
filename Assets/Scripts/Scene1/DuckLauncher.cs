/*
Spawns the ducks
!Attached to duck launcher prefab!
*/

using UnityEngine;
using System.Collections;

public class DuckLauncher : MonoBehaviour
{
    public float delay;
    public float rate;
    public float offset;
    public GameObject duck;

	void Start ()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);
    }
	
	void Spawn () //Time to spawn the ducks!
    {
        Instantiate(duck, new Vector2(6.0f, Random.Range(-0.44f, 1.8f)), Quaternion.identity);
	} 
}
