using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThatBus : MonoBehaviour
{
    public float speed = -1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
	}
}
