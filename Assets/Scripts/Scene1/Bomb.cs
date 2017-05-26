using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    SpriteRenderer bombRenderer;
    public GameObject player;
    public bool playerHitBomb;
    float timeToDisappear = 0f;
    float travelSpeed = -1.0f;

    int chanceOfSpin;
    float spinSpeed = -2.0f;

    void Start()
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
        chanceOfSpin = Random.Range(0, 100);
        ChangeBombSpeed();
        Spin();

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
        }
    }

    void ChangeBombSpeed()
    {
        switch (ScoreTracker.score)
        {
            case 25:
                travelSpeed = -1.25f;
                break;

            case 50:
                travelSpeed = -1.5f;
                break;

            case 75:
                travelSpeed = -1.75f;
                break;

            case 100:
                travelSpeed = 2.0f;
                break;
        }
    }

    void Spin()
    {
        if (chanceOfSpin <= 45)
        {
            transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
        }
    }
}
