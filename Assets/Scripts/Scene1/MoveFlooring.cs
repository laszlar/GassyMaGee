/*
May need to retire.
Original idea, but not the best.
!attached to plank prefab!
Original idea was to move the planks
in a "wave" format after a certain score
but this doesn't look that good.
I think I have better idea.
*/

using UnityEngine;
using System.Collections;

public class MoveFlooring : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float slowMover;
    ScoreTracker checkScore;

    GameObject player;
    Vector2 playerPos;

    public float amplitudeX = 10.0f;
    public float amplitudeY = 5.0f;
    public float omegaX = 1.0f;
    public float omegaY = 5.0f;
    public float offset;
    private float counter;
    private bool move;

    float index;
    float checkScoreTime = 1.0f;
    bool checkLevelOne = false;
    bool running;


    // Use this for initialization
    void Start ()
    {
        //player = GameObject.Find("Player");
        //checkScore = GameObject.Find("Score").GetComponent<ScoreTracker>();
        move = false;
        counter = 0f;
	}

	void Update ()
    {
        //playerPos.x = player.transform.position.x;
        //amplitudeX = playerPos.x + offset;
        counter += Time.deltaTime;

        if (counter >= 1.0f)
            move = true;

        if (move)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
        }



      /*(  if (!running)                                               //continuously check score
        {
            StartCoroutine(WaitToCheckScore(checkScoreTime));               
        }*/
  

        /*if(checkLevelOne)                                           //Start the sin wave after score is greater than 10. (temp)
        {
            //transform.Translate((plankMover/2) * Time.deltaTime, 0f, 0f);
            index += Time.deltaTime / slowMover; //this changes the X speed as it technically slows down time. Increase paintSpeed to slow it down further.
            float x = playerPos.x; //amplitudeX * Mathf.Cos(omegaX * index); //amplitude X is the X value as where it'll generate while omegaX shouldn't really be touched. 
            float y = amplitudeY * Mathf.Sin(omegaY * index); // amplitude Y is the Y value as where it'll generate and omegaY is how many times it goes up and down.
            transform.localPosition = new Vector3(x, y, 0);
            //transform.Translate(x, -Mathf.Pow(x, 2), 0); */


        }
    }

    /*IEnumerator WaitToCheckScore (float checkScoreTime)                     //Enumerator for coroutine.
    {
        running = true;
        yield return new WaitForSeconds(checkScoreTime);
        running = false;
        if (checkScore.levelOne)
        {
            checkLevelOne = true;
        }
    }
}*/
