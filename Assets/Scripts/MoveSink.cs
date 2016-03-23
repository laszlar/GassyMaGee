using UnityEngine;
using System.Collections;

public class MoveSink : MonoBehaviour
{
    public float sinkSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(sinkSpeed * Time.deltaTime, 0f, 0f);
	}
}
