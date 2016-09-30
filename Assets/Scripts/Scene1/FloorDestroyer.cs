/*
Not in use! Decommissioned.
*/

using UnityEngine;
using System.Collections;

public class FloorDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

            Destroy(coll.gameObject);
            Debug.Log("I hit the plank");
       
    }
}
