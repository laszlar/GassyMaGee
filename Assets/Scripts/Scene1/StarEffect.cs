using UnityEngine;
using System.Collections;

public class StarEffect : MonoBehaviour {

    PlayerMovement playerScript;
    ParticleSystem stars;
    ParticleSystem.EmissionModule starEffectGo;


    void Awake()
    {
        StarEffectOff();
    }

	void Start ()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
	
	void Update ()
    {
	    if (playerScript.godMode)
        {
            StarEffectOn();
        }
        else
        {
            StarEffectOff();
        }
	}

    //Turns Stars particle offect off
    void StarEffectOff ()
    {
        stars = GetComponent<ParticleSystem>();
        starEffectGo = stars.emission;
        starEffectGo.enabled = false;
    }

    //turns star particle effect on
    void StarEffectOn()
    {
        stars = GetComponent<ParticleSystem>();
        starEffectGo = stars.emission;
        starEffectGo.enabled = true;
    }
}
