/*
Destroys the planks
!attached to plank destroyer!
*/

using UnityEngine;
using System.Collections;

public class PlankDestroyingTime : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Plank")
        {
            Destroy(coll.gameObject);
            PlankSpawner.Planks.RemoveAt(0);
        }
    }
}
