using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDestroyer : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == null)
            return;

        if (coll.gameObject.tag == "Wave")
        {
            Destroy(coll.gameObject);
            if (WaveSpawner.Waves0.Count != 0 && WaveSpawner.Waves1.Count != 0 && WaveSpawner.Waves2.Count != 0 &&
                WaveSpawner.Waves3.Count != 0)
            {
                WaveSpawner.Waves0.RemoveAt(0);
                WaveSpawner.Waves1.RemoveAt(0);
                WaveSpawner.Waves2.RemoveAt(0);
                WaveSpawner.Waves3.RemoveAt(0);
            }
        }    
    }
}
