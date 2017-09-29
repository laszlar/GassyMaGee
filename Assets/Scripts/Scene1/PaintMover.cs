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

    public GameObject player;
    float paintPos;
    float playerPos;
    float actualPos;
    float offset = 5f;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
	}

    // Update is called once per frame
    void FixedUpdate ()                          //Gives it a nice Sin wave for goofiness :)
    {
        playerPos = player.transform.position.x;
        actualPos = playerPos + offset;
        paintPos = transform.position.x;

        index += Time.deltaTime / paintSpeed; //this changes the X speed as it technically slows down time. Increase paintSpeed to slow it down further.
        float x = amplitudeX * Mathf.Cos(omegaX * index); //amplitude X is the X value as where it'll generate while omegaX shouldn't really be touched. 
        float y = amplitudeY * Mathf.Sin(omegaY * index); // amplitude Y is the Y value as where it'll generate and omegaY is how many times it goes up and down.
        transform.localPosition = new Vector3((actualPos + x), y, 0);

        if (paintPos <= 0.05f)
        {
            Destroy(gameObject);
        }
    }


}
