/*This Script is not in use! 
Decommissioned for right now.
May use it for another game,
or later time. */

using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSize;
    float newPosition = 0f;

    Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        newPosition += Time.deltaTime * scrollSpeed;

        while (newPosition >= tileSize)
        {
            newPosition -= tileSize;
        }
 
        transform.position = startPosition + (Vector2.left * newPosition);
    }
}


