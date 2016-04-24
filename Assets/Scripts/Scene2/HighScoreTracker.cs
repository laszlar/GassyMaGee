using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreTracker : MonoBehaviour
{
    ScoreTracker scoreTracker;
    public int highScore;
    Text text;

	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        scoreTracker = GetComponent<ScoreTracker>();
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        highScore = scoreTracker.highScore;
        text.text = "" + highScore;
	}
}
