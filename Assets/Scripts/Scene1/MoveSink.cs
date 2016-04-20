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
            Debug.Log("Sink is coming");
            transform.Translate(sinkSpeed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            Debug.Log("Sink half speed");
            transform.Translate(halfSinkSpeed * Time.deltaTime, 0f, 0f);
        }
	}
}
