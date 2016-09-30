/*
Moves the paint powerup
!Attached to paint prefab!
*/

using UnityEngine;
using System.Collections;

public class PaintMover : MonoBehaviour {

    public float paintSpeed;

    public float amplitudeX = 10.0f;
    public float amplitudeY = 5.0f;
    public float omegaX = 1.0f;
    public float omegaY = 5.0f;
    float index;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()                          //Gives it a nice Sin wave for goofiness :)
    {
        index += Time.deltaTime / paintSpeed; //this changes the X speed as it technically slows down time. Increase paintSpeed to slow it down further.
        float x = amplitudeX * Mathf.Cos(omegaX * index); //amplitude X is the X value as where it'll generate while omegaX shouldn't really be touched. 
        float y = amplitudeY * Mathf.Sin(omegaY * index); // amplitude Y is the Y value as where it'll generate and omegaY is how many times it goes up and down.
        transform.localPosition = new Vector3(x, y, 0);
    }


}
