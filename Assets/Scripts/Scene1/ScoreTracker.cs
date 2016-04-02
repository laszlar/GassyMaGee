using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTracker : MonoBehaviour {

	public int pts = 0;
    PlayerMovement playerMove;
    Text text;

	void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        text = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        pts = playerMove.points;
        text.text = "" + pts;
	}
}
