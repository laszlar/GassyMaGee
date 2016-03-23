using UnityEngine;
using System.Collections;

public class DuckLauncher : MonoBehaviour
{
    //Just updating this to force GitHub to update for the Camera effects
    public float delay = 0.1f;
    public GameObject duck;
    public float duckSpawnLocation;


	void Start ()
    {
        InvokeRepeating("Spawn", delay, delay);  //InvokeRepeating(string methodName, float time, float repeatRate);
    }
	
	void Spawn () //Time to spawn the ducks!
    {
        GameObject duckInst = Instantiate(duck, new Vector2(duckSpawnLocation, Random.Range(-0.7f, 1)), Quaternion.identity) as GameObject;
        duckInst.gameObject.tag = "Enemy";
	} 
}
