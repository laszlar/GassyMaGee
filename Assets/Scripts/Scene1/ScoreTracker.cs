/*
Score tracker...
!attached to canvas/score!
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTracker : MonoBehaviour
{

    PlayerMovement player;
    PlankSpawner plank;
    Text text;
    public int score;
    public int highScore;
    public bool levelOne;

    void Awake ()
    {
        highScore = PlayerPrefs.GetInt("High Score");
    }


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        text = gameObject.GetComponent<Text>();

        plank = GetComponent<PlankSpawner>();
    }
	
	// Update is called once per frame
	void Update ()
    {
       score = player.points;
       text.text = "" + score;
       if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("High Score", highScore);
            PlayerPrefs.Save();
        }

       if(score > 10)
        {
            levelOne = true;
        }

       switch (score)
        {
            case 100: plank.plankPercent = 80;
                break;
            case 75: plank.plankPercent = 90;
                break;
            case 50: plank.plankPercent = 95;
                break;
        }

	}
}
