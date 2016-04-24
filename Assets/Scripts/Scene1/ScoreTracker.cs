using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTracker : MonoBehaviour {

    PlayerMovement playerMove;
    Text text;
    public int points = 0;
    public int highScore;

	void Start()
    {
        DontDestroyOnLoad(transform.root.gameObject);
        playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        text = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
       points = playerMove.points;
       text.text = "" + points;
       if (points > highScore)
        { 
            highScore = points;
            PlayerPrefs.SetInt("highScore", highScore);
        }
	}
}
