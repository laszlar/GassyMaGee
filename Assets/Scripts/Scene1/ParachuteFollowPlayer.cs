using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteFollowPlayer : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement playerScript;
    private float offsetX = 0.30f;
    private float offsetY = 0.12f;
    public Vector2 position;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = position;
        position = new Vector2((player.transform.position.x - offsetX), (player.transform.position.y + offsetY));

        if(!playerScript.parachuteEnabled)
        {
             Destroy(gameObject);
        }
	}
}
