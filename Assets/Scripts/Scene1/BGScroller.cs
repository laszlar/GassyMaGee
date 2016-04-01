using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;
    public float tileSize;

    private Vector2 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        transform.position = startPosition + Vector2.left * newPosition;
	}
}
