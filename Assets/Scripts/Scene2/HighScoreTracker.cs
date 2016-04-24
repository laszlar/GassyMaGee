using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreTracker : MonoBehaviour
{
    Text text;
    public int currentScore;

	void Start ()
    {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentScore = PlayerPrefs.GetInt("High Score");
        text.text = "" + currentScore;
    }
}
