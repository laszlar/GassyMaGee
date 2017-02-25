using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMover : MonoBehaviour
{
    //decrease this value to speed the object up
    [SerializeField]
    private float trailSpeed = 1.5f; 
    [SerializeField]
    private float amplitudeX = 10.0f;
    [SerializeField]
    private float amplitudeY = 0.75f;
    [SerializeField]
    private float omegaX = 1.0f;
    [SerializeField]
    private float omegaY = 5.0f;

    private float x;
    private float y;
    

    private float timeIndex;
    private float trailXOffset;

    private GameObject player;
    private float playerPos;
    [SerializeField]
    private float offset = 0.0f;

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
