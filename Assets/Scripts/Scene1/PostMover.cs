using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostMover : MonoBehaviour
{
    //Mover's variables
    private float speed = -1.0f;
    private float slowSpeed = -0.5f;
    private float fastSpeed = -1.5f;
    private BoxCollider2D box;
    public float boxWidth;
    public float scale;
    public float actualBoxWidth;

    //Player's variables
    private GameObject player;
    PlayerMovement playerScript;

    // Use this for initialization
    void Start()
    {
        //find player object/script on startup
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();

        //this object's width
        box = GetComponent<BoxCollider2D>();
        boxWidth = box.size.x;
        scale = gameObject.transform.localScale.x;
        actualBoxWidth = boxWidth * scale;
    }

    // Update is called once per frame
    private void Update()
    {
        //If neither banana or parachute is active BG moves at regular speed.
        if (!playerScript.parachuteEnabled && !playerScript.bananaEnabled ||
            playerScript.parachuteEnabled && playerScript.bananaEnabled)
            transform.Translate((speed * Time.deltaTime), 0f, 0f);

        if (playerScript.bananaEnabled && !playerScript.parachuteEnabled)
        {
            SpeedUp();
        }

        if (playerScript.parachuteEnabled && !playerScript.bananaEnabled)
        {
            SlowDown();
        }
    }

    void SlowDown()
    {
        transform.Translate((slowSpeed * Time.deltaTime), 0f, 0f);
    }

    void SpeedUp()
    {
        transform.Translate((fastSpeed * Time.deltaTime), 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "FloorBoundaryDestroyer")
        {
            transform.Translate(actualBoxWidth * 4, 0f, 0f);
        }
    }
}
