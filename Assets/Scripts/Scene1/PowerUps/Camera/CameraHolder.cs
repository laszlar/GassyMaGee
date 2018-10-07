using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    //Player Script
    private PlayerMovement playerScript;

    //float variables for moving this object
    private float moveSpeed = -1.0f;
    private float slowSpeed = -0.5f;

    //Methods
    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    } 

    void Update ()
    {
        //destory this game object if the player collides with it
        if (playerScript.cameraPowerUpFlag)
            Destroy(gameObject);

        //If neither banana or parachute is active camera moves at regular speed.
        if (!playerScript.parachuteEnabled)
            transform.Translate((moveSpeed * Time.deltaTime), 0f, 0f);

        //slow down camera power up if parachute is enabled
        if (playerScript.parachuteEnabled)
            SlowDown();      
    }

    void SlowDown()
    {
        transform.Translate((slowSpeed * Time.deltaTime), 0f, 0f);
    }
}
