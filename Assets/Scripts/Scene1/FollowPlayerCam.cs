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
    public int cameraFollowSpeed = 1;
    public GameObject player;
    public Vector3 offset;
    public float deadZone;
    Vector3 targetPos;
    Vector3 lerpidyLerpLerpDerp;

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

        interVelocity = targetDirection.magnitude * cameraFollowSpeed; //Adjust the camera follow speed in the editor to increase/decrease it's spead.. i.e. the lower the value the slower it follows

        targetPos = transform.position + (targetDirection.normalized * interVelocity * Time.deltaTime); //the actual moving of the camera

        lerpidyLerpLerpDerp = Vector3.Lerp(transform.position, targetPos + offset, 0.03f);
        lerpidyLerpLerpDerp.y = Mathf.Clamp(lerpidyLerpLerpDerp.y, -0.05f, 10.0f);
        transform.position = lerpidyLerpLerpDerp;
    }
}
