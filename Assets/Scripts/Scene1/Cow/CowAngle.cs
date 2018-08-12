using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowAngle : MonoBehaviour
{
    //Array
    private int[] cowRotationAngle;

	// Use this for initialization
	void Start ()
    {
        //initialize the rotation angle array
        cowRotationAngle = new int[] { 0, 90, 180, 270 };

        //random rotation of cow for fun :)
        transform.Rotate(0f, 0f, cowRotationAngle[Random.Range(0, 3)]);
	}

}
