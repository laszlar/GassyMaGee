using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowAngle : MonoBehaviour
{
    //Array
    private int[] cowRotationAngle;

    //Get player info
    PlayerMovement playerScript;

    //audio source
    private AudioSource source;

	void Start ()
    {
        //Retrieve script
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

        //Retrieve audio component
        source = GetComponent<AudioSource>();
        
        //initialize the rotation angle array
        cowRotationAngle = new int[] { 0, 90, 180, 270 };

        //random rotation of cow for fun :)
        transform.Rotate(0f, 0f, cowRotationAngle[Random.Range(0, 3)]);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerScript.godMode)
            source.Play();
    }

}
