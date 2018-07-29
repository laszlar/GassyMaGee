using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostManager : MonoBehaviour
{
    //set the array for the posts
    public GameObject[] postArray = new GameObject[4];

    //Vector2 information
    private Vector2 originalPOS;
    private Vector2 nextPOS;

    //Post GameObjects
    private GameObject post;
    private PostMover postScript;

    private void Start()
    {
        //create the positions for spawning the posts
        originalPOS = new Vector2(1.23f, -0.76f);
        nextPOS = new Vector2((originalPOS.x + 3.293226313f), -0.76f);

        //spawn the posts
        for (int x = 0; x < 4; x++)
        {
            if (x == 0)
            {
                Instantiate(postArray[x], originalPOS, Quaternion.identity);
            }
            else
            {
                Instantiate(postArray[x], nextPOS, Quaternion.identity);
                nextPOS.x += 3.293226313f;
            }
        }

    }
}
