using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpinner : MonoBehaviour
{

    private float spinSpeed = 180.0f;
	
	void Update ()
    {
        //spin this camera
        transform.Rotate(0, 0, -spinSpeed * Time.deltaTime);
	}
}
