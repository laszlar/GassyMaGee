using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpin : MonoBehaviour
{
    public float spinSpeed;
    public float waveSize;
    private float uppersAndDowners;
    private float randomHeight;
    Vector3 moveLeft;

	// Use this for initialization
	void Start ()
    {
        waveSize = GetComponent<Renderer>().bounds.size.x;
	}
	
    void FixedUpdate()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}
