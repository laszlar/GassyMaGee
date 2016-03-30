using UnityEngine;
using System.Collections;

public class KettleLauncher : MonoBehaviour
{
    public float delay;
    public float rate;
    public GameObject kettle;
    public float kettleSpawnLocation;


    void Start()
    {
        InvokeRepeating("Spawn", delay, rate);  //InvokeRepeating(string methodName, float time, float repeatRate);
    }

    void Spawn() //Time to spawn the ducks!
    {
        GameObject duckInst = Instantiate(kettle, new Vector2(kettleSpawnLocation, Random.Range(-0.7f, 1)), Quaternion.identity) as GameObject;
        duckInst.gameObject.tag = "Enemy";
    }
}
