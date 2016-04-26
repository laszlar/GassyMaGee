using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreTracker : MonoBehaviour
{
    Text text;
    public int highScore;


    void Start ()
    {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        highScore = PlayerPrefs.GetInt("High Score");
        text.text = "" + highScore;
    }
}
