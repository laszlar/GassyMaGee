using UnityEngine;
using System.Collections;

public class BGmover : MonoBehaviour
{
    private float moveSpeed = 0.5f;
    private float slowSpeed = 0.25f;
    PlayerMovement playerScript;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();    
    } 

    private void FixedUpdate()
    {
        transform.Translate((-moveSpeed * Time.deltaTime), 0f, 0f);
    }

    void SlowDown()
    {
        transform.Translate((slowSpeed * Time.deltaTime), 0f, 0f);
    }
}
