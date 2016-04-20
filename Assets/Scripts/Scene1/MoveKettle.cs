using UnityEngine;
using System.Collections;

public class MoveKettle : MonoBehaviour {

    public float kettleSpeed;
    public float halfKettleSpeed;
    PlayerMovement script;
    
    // Use this for initialization
	void Start ()
    {
        script = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!script.kettleThing)
        {
            transform.Translate(kettleSpeed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            transform.Translate(halfKettleSpeed * Time.deltaTime, 0f, 0f);
        }
	}
}
