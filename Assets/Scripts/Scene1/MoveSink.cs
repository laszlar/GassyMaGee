using UnityEngine;
using System.Collections;

public class MoveSink : MonoBehaviour
{
    public float sinkSpeed;
    public float halfSinkSpeed;
    PlayerMovement script;

	// Use this for initialization
	void Start ()
    {
        script = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!script.sinkThing)
        {
            transform.Translate(sinkSpeed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            transform.Translate(halfSinkSpeed * Time.deltaTime, 0f, 0f);
        }
	}
}
