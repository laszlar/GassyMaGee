using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private GameObject player;
    public Vector2 currentPos;
    public float yPos;
    private float playerXCoordinate;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate ()
    {
        transform.position = currentPos;
        currentPos = new Vector2(player.transform.position.x, yPos);
	}
}
