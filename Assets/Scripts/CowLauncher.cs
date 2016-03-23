using UnityEngine;
using System.Collections;

public class CowLauncher : MonoBehaviour
{

    public float delay = 0.1f;
    public GameObject cow;
    public float cowSpawnLocation;

    void Start ()
    {
        InvokeRepeating("Spawn", delay, delay);
    }

    void Spawn ()
    {
        GameObject cowInst = Instantiate(cow, new Vector2(cowSpawnLocation, Random.Range(-0.6f, 1)), Quaternion.identity) as GameObject;
		cowInst.gameObject.tag = "Enemy";
    } 
}
