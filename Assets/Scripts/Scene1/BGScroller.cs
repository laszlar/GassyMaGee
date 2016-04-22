using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSize;
    float halfScrollSpeed;
    float newPosition = 0f;

    PlayerMovement script;

    Vector2 startPosition;
    //Vector2 newPosition;

    // Use this for initialization
    void Start()
    {
        script = GameObject.Find("Player").GetComponent<PlayerMovement>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       /* if (!script.scrollerThing) //If power up NOT activated scroll at regular speed.
        {
            float floatNewPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
            newPosition = new Vector2(-floatNewPosition, 0f);
            transform.position = startPosition + newPosition;
        }
        else //Power up activated resulting in half speed of scrolling.
        {
            halfScrollSpeed = scrollSpeed / 2;
            float floatNewPosition = Mathf.Repeat(Time.time * halfScrollSpeed, tileSize);
            newPosition = new Vector2(-floatNewPosition, 0f);
            transform.position = startPosition + newPosition;*/

      if(!script.scrollerThing)
        {
            newPosition += Time.deltaTime * scrollSpeed;
        }  
      else
        {
            halfScrollSpeed = scrollSpeed / 2;
            newPosition += Time.deltaTime * halfScrollSpeed;
        }

        while (newPosition >= tileSize)
            newPosition -= tileSize;
        transform.position = startPosition + (Vector2.left * newPosition);
    }
}


