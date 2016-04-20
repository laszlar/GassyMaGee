using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;
    public float halfScrollSpeed;
    public float tileSize;
    PlayerMovement script;

    private Vector2 startPosition;

	// Use this for initialization
	void Start ()
    {
        script = GameObject.Find("Player").GetComponent<PlayerMovement>();
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!script.scrollerThing)
        {
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
            transform.position = startPosition + Vector2.left * newPosition;
        }
        else
        {
            float newPosition = Mathf.Repeat(Time.time * halfScrollSpeed, tileSize);
            transform.position = startPosition + Vector2.left * newPosition;
        }
	}
}
