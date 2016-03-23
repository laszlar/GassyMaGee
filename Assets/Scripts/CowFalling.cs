using UnityEngine;
using System.Collections;

public class CowFalling : MonoBehaviour {

    public float delay = 0.1f;
    public GameObject cow;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Spawn", delay, delay);
	}
	
	void Spawn ()
    {
        Instantiate(cow, new Vector3(Random.Range(-6, 6), 3, 0),Quaternion.identity);
	}
}
