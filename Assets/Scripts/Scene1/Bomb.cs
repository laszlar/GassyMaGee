using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    SpriteRenderer bombRenderer;
    private GameObject player;
    private PlayerMovement playerScript;
    public bool playerHitBomb;
    float timeToDisappear = 0f;
    float travelSpeed = -1.0f;

    float spinSpeed = -2.0f;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();
        playerHitBomb = false;
        bombRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //reset timer
            if (timeToDisappear != 0f)
            {
                timeToDisappear = 0f;
            }
            playerHitBomb = true;
        }
    }

    void Update()
    {
        if (playerHitBomb)
        {
            bombRenderer.enabled = false;
            timeToDisappear += Time.deltaTime;

            //if timer = 1, destroy bomb
            if (timeToDisappear >= 1.0f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(travelSpeed * Time.deltaTime, 0f, 0f);

            //check for powerups and adjust speed accordingly!
            if (!playerScript.parachuteEnabled && !playerScript.bananaEnabled ||
            playerScript.parachuteEnabled && playerScript.bananaEnabled)
                transform.Translate((travelSpeed * Time.deltaTime), 0f, 0f);

            if (playerScript.bananaEnabled && !playerScript.parachuteEnabled)
            {
                SpeedUp();
            }

            if (playerScript.parachuteEnabled && !playerScript.bananaEnabled)
            {
                SlowDown();
            }
        }
    }

    void SpeedUp()
    {
        transform.Translate(((travelSpeed * 1.5f) * Time.deltaTime), 0f, 0f);
    }

    void SlowDown()
    {
        transform.Translate(((travelSpeed * 0.5f) * Time.deltaTime), 0f, 0f);
    }
}
