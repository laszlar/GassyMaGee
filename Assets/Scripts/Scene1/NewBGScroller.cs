/*
Not in use! 
*/

using UnityEngine;
using System.Collections;

public class NewBGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float halfScrollSpeed;
    public float tileSize;
    PlayerMovement script;

    Vector2 startPosition;
    Vector2 newPosition;

    // Use this for initialization
    void Start()
    {
        script = GameObject.Find("Player").GetComponent<PlayerMovement>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!script.scrollerThing)
        {
            float floatNewPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
            newPosition = new Vector2(-floatNewPosition, 0f);
            transform.position = startPosition + newPosition;
            //transform.position = Vector2.Lerp(transform.position, newPosition, 0.5f);
        }
        else
        {
            float newPosition = Mathf.Repeat(Time.time * halfScrollSpeed, tileSize);
            transform.position = startPosition + Vector2.left * newPosition;
        }
    }
}
