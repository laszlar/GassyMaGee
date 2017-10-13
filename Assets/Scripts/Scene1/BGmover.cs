using UnityEngine;
using System.Collections;

public class BGmover : MonoBehaviour
{
    private float moveSpeed = -0.50f;
    private float slowSpeed = -0.25f;
    private float fastSpeed = -0.75f;
    PlayerMovement playerScript;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //If neither banana or parachute is active BG moves at regular speed.
        if (!playerScript.parachuteEnabled && !playerScript.bananaEnabled ||
            playerScript.parachuteEnabled && playerScript.bananaEnabled)
        transform.Translate((moveSpeed * Time.deltaTime), 0f, 0f);

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
}
