using UnityEngine;
using System.Collections;

public class PowEffect : MonoBehaviour
{
    PlayerMovement playerScript;
    ParticleSystem hit;
    ParticleSystem.EmissionModule isHitting;

	void Awake ()
    {
        GetComponent<ParticleEmitter>().enabled = false;
    }
    
    // Use this for initialization
	void Start ()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (playerScript.punch)
        {
            PowEffectOn();
        }
        else
        {
            PowEffectOff();
        }
	}

    void PowEffectOff()
    {
        hit = GetComponent<ParticleSystem>();
        isHitting = hit.emission;
        isHitting.enabled = false;
    }

    void PowEffectOn ()
    {
        hit = GetComponent<ParticleSystem>();
        isHitting = hit.emission;
        isHitting.enabled = true;
    }
}
