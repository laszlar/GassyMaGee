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
    Text text;
    public static int score;
    public int highScore;
    public bool levelOne;

    //Game Object Variables
    GameObject kettle;
    GameObject fatty;
    GameObject bomb;

    void Awake ()
    {
        highScore = PlayerPrefs.GetInt("High Score");
    }


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        text = gameObject.GetComponent<Text>();

        kettle = GameObject.Find("KettleLaunching");
        fatty = GameObject.Find("FattyCannon");
        bomb = GameObject.Find("BombCannon");

        kettle.SetActive(false);
        fatty.SetActive(false);
        bomb.SetActive(false);
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

       //if the score is greater than 50 start limiting the number of planks that spawn
       ChangePlankPercent();

        //Launch game objects depending on the score
        GameObjectLogicLauncher();
	}

    public static void ChangePlankPercent()
    {
        switch (score)
        {
            case 100:
                PlankSpawner.plankPercent = 75;
                break;
            case 50:
                PlankSpawner.plankPercent = 80;
                break;
            case 25:
                PlankSpawner.plankPercent = 90;
                break;
            case 1:
                PlankSpawner.plankPercent = 95;
                break;
        }
    }

    private void GameObjectLogicLauncher()
    {
        switch (score)
        {
            case 50:
                fatty.SetActive(true);
                break;
            case 25:
                bomb.SetActive(true);
                break;
            case 10:
                kettle.SetActive(true);
                break;
        }
    }
}
