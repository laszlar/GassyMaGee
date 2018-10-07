using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraSpinner : MonoBehaviour
{
    //Player Script
    private PlayerMovement playerScript;

    //float variables for this powerup
    private float cameraSpinSpeed = -120.0f;
    private float currentZvalue;
    private float maxValue = -1.0f;

    //bool variables
    private bool resetCameraPowerUp;

    //Main Methods
	void Start ()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

        //Initially set the camera to has not spun yet!
        resetCameraPowerUp = false;
	}
	
	void Update ()
    {
        //acquire the camera rotation at all times
        currentZvalue = transform.rotation.z;
        Debug.Log("This is the camera z value " + currentZvalue);
        if (playerScript.cameraPowerUpFlag)
        {
            //set this up to spin the camera back to start
            resetCameraPowerUp = true;

            //spin the camera
            if (currentZvalue >= maxValue)
            {
                transform.Rotate(0f, 0f, cameraSpinSpeed * Time.deltaTime);
            }
            //else
                //transform.Rotate(0f, 0f, maxValue);

        }	

        //reset the camera to origin rotation
        if (resetCameraPowerUp && !playerScript.cameraPowerUpFlag)
        {
            if (currentZvalue <= 0f)
            {
                transform.Rotate(0f, 0f, -cameraSpinSpeed * Time.deltaTime);
            }
        }
	}
}
