using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHolderBehaviour : MonoBehaviour
{
    float movementY;
    float movementX;
    float movement;
    float timeIndex;
    float omegaY = 300;
    float randomizeYMovement;

	// Use this for initialization
	void Start ()
    {
        randomizeYMovement = Random.Range(0.005f, 0.01f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {      
        //increasing the number dividing the time doesn't just slow it down, but it also increases the up and down movement
        timeIndex += Time.deltaTime / 20;
        //This makes it do the up and down movement
        movementY = Mathf.Sin(omegaY * timeIndex);
        //this line makes it actually move
        transform.Translate((-0.3f * Time.deltaTime), randomizeYMovement * movementY, 0f);
    }

    float Hermite(float t)
    {
        return -t * t * t * 2 + t * t * 3;
    }
}
