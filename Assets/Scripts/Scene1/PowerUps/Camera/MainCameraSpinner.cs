using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraSpinner : MonoBehaviour
{
    //Player Script
    private PlayerMovement playerScript;

    //float variables for this powerup
    private float cameraSpinSpeed = -220.0f;
    private float currentZvalue;
    private float maxValue = -180.0f;

    //bool variables
    private bool resetCameraPowerUp;

    //Quaternion variable (for Euler angles)
    //private Quaternion zValueEuler;

    //Main Methods
	void Start ()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

        //Initially set the camera to has not spun yet!
        resetCameraPowerUp = false;

        //zValueEuler = Quaternion.Euler(0, currentZvalue, 0);
	}
	
	void Update ()
    {
        if (playerScript.cameraPowerUpFlag && !resetCameraPowerUp)
        {
            //spin the camera
            if (currentZvalue >= maxValue)
            {
                transform.rotation = Quaternion.Euler(0, 0, maxValue);
            }

            //set this up to spin the camera back to start
            resetCameraPowerUp = true;
        }	

        //reset the camera to origin rotation
        if (resetCameraPowerUp && !playerScript.cameraPowerUpFlag)
        {
            if (currentZvalue <= 0f)
            {
                currentZvalue = 0f;
                transform.rotation = Quaternion.Euler(0, 0, currentZvalue);
            }

            //reset the camera!
            resetCameraPowerUp = false;
        }
	}
}
