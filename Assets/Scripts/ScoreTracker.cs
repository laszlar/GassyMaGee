using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTracker : MonoBehaviour {

	public int pts = 0;

	void Start() {
		pts = GameObject.Find("Player").GetComponent<PlayerMovement>().points;
	}
	
	// Update is called once per frame
	void Update ()
    { 
		Text text = gameObject.GetComponent<Text> ();
		text.text = " " + pts;
	}
}
