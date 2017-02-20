using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMover : MonoBehaviour
{
    //decrease this value to speed the object up
    private float trailSpeed = 3.0f; 

    private float amplitudeX = 10.0f;
    private float amplitudeY = 0.75f;
    private float x;
    private float y;
    private float omegaX = 1.0f;
    private float omegaY = 5.0f;

    private float timeIndex;
    private float trailXOffset;

    private GameObject player;
    private float playerPos;
    private int offset = 1;

    private Vector2 cubePos;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerPos = player.transform.position.x;
        trailXOffset = playerPos + offset;

        timeIndex += Time.deltaTime / trailSpeed;
        x = amplitudeX * Mathf.Cos(omegaX * timeIndex);
        y = amplitudeY * Mathf.Sin(omegaY * timeIndex);
        cubePos = new Vector2((trailXOffset + x), y);
        transform.position = cubePos;
	}
}
