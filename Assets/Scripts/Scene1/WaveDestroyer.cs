using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDestroyer : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Wave")
        {
            Destroy(coll.gameObject);
            WaveSpawner.Waves.RemoveAt(0);
        }    
    }

}
