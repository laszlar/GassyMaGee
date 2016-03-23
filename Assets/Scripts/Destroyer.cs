using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
