using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlanks : MonoBehaviour
{

    private float speed = -1.0f;

    // Use this for initialization

	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
	}
}
