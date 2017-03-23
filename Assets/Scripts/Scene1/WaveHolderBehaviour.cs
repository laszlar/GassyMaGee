using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHolderBehaviour : MonoBehaviour
{
    //Variables are for moving the waves appropriately
    float movementY;
    float timeIndex;
    //Original -----  float omegaY = 300;
    float omegaY = 45f; //30 worked pretty well...
    float randomizeYMovement;

	void Start ()
    {
        //for the up and down randomization
        randomizeYMovement = Random.Range(0.005f, 0.015f);
    }

    //Fixedupdate is called less than per frame if the frame rate is high, however will call more than once per frame if FPS is low
    void FixedUpdate()
    {      
        //This is where I keep the info to make the waves move on their own
        //best to keep the number divided between 1 - 100, if you make it closer to OmegaY, it'll do the reverse effect
        timeIndex += Time.deltaTime / 30;
        movementY = Mathf.Sin(omegaY * timeIndex);
        //Original === transform.Translate(0f, (0.015f * movementY), 0f);
        transform.Translate(0f, (0.005f * movementY), 0f);
    }
}
