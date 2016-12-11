using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePostsRopeBG : MonoBehaviour
{
    public GameObject postsAndFuckingRope;
    public GameObject player;
    float currentPosition;                              
    float xValueOfPostsAndRope = 3.293226313f;
    float newPosition;
    bool spawnAlright;
    Vector2 xPosition;
    float playerPosition;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        playerPosition = player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        while (playerPosition < 3)
            spawnAlright = true;
        
        if (spawnAlright)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        currentPosition = transform.position.x;                                 //get the  current position
        newPosition = currentPosition + xValueOfPostsAndRope;
        xPosition = new Vector2(newPosition, 0);                                //save the Vector2
        Instantiate(postsAndFuckingRope, xPosition, transform.rotation);        //spawn bitches.
    }
}
