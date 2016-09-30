/*
Unique follow cam.
!Attached to Main camera!
*/

using UnityEngine;
using System.Collections;

public class FollowPlayerCam : MonoBehaviour
{

    public float interVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject player;
    public Vector3 offset;
    Vector3 targetPos;

	// Use this for initialization
	void Start ()
    {
        targetPos = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        //transform.position = player.transform.position + offset;
        Vector3 posZ = transform.position; //camera's position
        posZ.z = player.transform.position.z; //player position

        Vector3 targetDirection = (player.transform.position - posZ); //this tells the camera in which direction the player is moving/which direction to move

        interVelocity = targetDirection.magnitude * 5f; //The actual value on how quick to move the camera? 

        targetPos = transform.position + (targetDirection.normalized * interVelocity * Time.deltaTime); //the actual moving of the camera

        transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);


	}
}
