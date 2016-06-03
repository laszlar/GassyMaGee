using UnityEngine;
using System.Collections;

public class MovePlank : MonoBehaviour
{
    public float plankMover = -2.0f;
    public float slowMover;
    ScoreTracker checkScore;

    public float amplitudeX = 10.0f;
    public float amplitudeY = 5.0f;
    public float omegaX = 1.0f;
    public float omegaY = 5.0f;
    float index;
    float checkScoreTime = 1.0f;
    bool checkLevelOne = false;
    bool running;


    // Use this for initialization
    void Start ()
    {
        checkScore = GameObject.Find("Score").GetComponent<ScoreTracker>();
	}

	void Update ()
    {
        if (!running)
        {
            StartCoroutine(WaitToCheckScore(checkScoreTime));
        }

        transform.Translate(plankMover * Time.deltaTime, 0f, 0f);

        if(checkLevelOne)
        {
            //transform.Translate((plankMover/2) * Time.deltaTime, 0f, 0f);

            index += Time.deltaTime / slowMover; //this changes the X speed as it technically slows down time. Increase paintSpeed to slow it down further.
            float x = amplitudeX * Mathf.Cos(omegaX * index); //amplitude X is the X value as where it'll generate while omegaX shouldn't really be touched. 
            float y = amplitudeY * Mathf.Sin(omegaY * index); // amplitude Y is the Y value as where it'll generate and omegaY is how many times it goes up and down.
            transform.localPosition = new Vector3(x, y, 0);
        }

        
         
              

    
    }

    IEnumerator WaitToCheckScore (float checkScoreTime)
    {
        running = true;
        yield return new WaitForSeconds(checkScoreTime);
        running = false;
        if (checkScore.levelOne)
        {
            checkLevelOne = true;
        }
    }
}
