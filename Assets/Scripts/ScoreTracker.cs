using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTracker : MonoBehaviour {

	public int pts = 0;

	void Start() {

	}
	
	// Update is called once per frame
	void Update ()
    { 
		pts = GameObject.Find("Player").GetComponent<PlayerMovement>().points;
		Text text = gameObject.GetComponent<Text> ();
		text.text = " " + pts;
	}
}
