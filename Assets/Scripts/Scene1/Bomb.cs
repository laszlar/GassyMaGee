using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    SpriteRenderer bombRenderer;
    public GameObject player;
    public bool playerHitBomb;
    float timeToDisappear = 0f;

    private void Start()
    {
        player = GameObject.Find("Player");
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

    void Update ()
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
    }
}
