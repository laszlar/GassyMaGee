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
    private int testSize;
    private float testSizeFloat;

    void Awake ()
    {
        highScore = PlayerPrefs.GetInt("High Score");
    }


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        text = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
       score = player.points;
       text.text = "" + score;

       //Make the score look awesome on enemy hit!
       IncreaseTextSize();

       if (player.dead && score > highScore)
       {
           highScore = score;
           PlayerPrefs.SetInt("High Score", highScore);
           PlayerPrefs.Save();
       }
	}

    //make the score text size large on Enemy hit and then decrease rapidly! Also vibrate device.
    private void IncreaseTextSize()
    {
        if (PlayerMovement._isEnemy)
        {
            Handheld.Vibrate();
            text.fontSize = 150;
            testSize = 150;
        }

        /*if (text.fontSize > 72)
        {
            text.fontSize -= (int)Time.deltaTime * 4;
        }*/

        if (testSize > 72)
        {   
            {
                StartCoroutine(SlowDownDecrease(1));
                
            }
        }
        Debug.Log("This is my size: " + testSize);
    }

    IEnumerator SlowDownDecrease(int time)
    {
        while (testSize > 72)
        {
            testSize -= 1;
            yield return new WaitForSeconds(time);
        }
    }
}
