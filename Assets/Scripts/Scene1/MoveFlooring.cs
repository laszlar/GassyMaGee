/*
May need to retire.
Original idea, but not the best.
!attached to plank prefab!
Original idea was to move the planks
in a "wave" format after a certain score
but this doesn't look that good.
I think I have better idea.
*/

using UnityEngine;
using System.Collections;

public class MoveFlooring : MonoBehaviour
{
    private float moveSpeed = -0.5f;
    private float slowSpeed = -0.25f;
    private float fastSpeed = -0.75f;
    public float slowMover;

    GameObject player;
    PlayerMovement playerScript;

    public float offset;
    private float counter;
    private bool move;


    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();
        move = false;
        counter = 0f;
	}

	void Update ()
    {
        //playerPos.x = player.transform.position.x;
        //amplitudeX = playerPos.x + offset;
        counter += Time.deltaTime;

        if (counter >= 1.0f)
            move = true;

        //================================================//
        //Putting the values here to check for the power ups
        if (move)
        {
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

