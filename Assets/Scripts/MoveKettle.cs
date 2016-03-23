using UnityEngine;
using System.Collections;

public class MoveKettle : MonoBehaviour {

    public float kettleSpeed;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(kettleSpeed * Time.deltaTime, 0f, 0f);
	}
}
