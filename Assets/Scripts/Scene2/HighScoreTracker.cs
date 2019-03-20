using UnityEngine;
using UnityEngine.UI;
//using System.Collections;

public class HighScoreTracker : MonoBehaviour
{
    Text text;
    public int highScore;

    //booleans
    private bool storeOnce;

    //objects
    //PlayGamesScript playScript;

    void Start ()
    {
        //find componenents
        text = GetComponent<Text>();
        //playScript = GameObject.Find("UIManager").GetComponent<PlayGamesScript>();

        highScore = PlayerPrefs.GetInt("High Score");
        text.text = "" + highScore;

        //bool for doing once on Update
        storeOnce = false;
    }

    void Update ()
    {
        if (!storeOnce)
        {
            //PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_gassy_magee_leaderboard, highScore);
            storeOnce = true;
        }
    }
}
