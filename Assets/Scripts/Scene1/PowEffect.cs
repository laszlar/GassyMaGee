/*
Tried to implement
but is not working.
*/

using UnityEngine;
using System.Collections;

public class PowEffect : MonoBehaviour
{
    PlayerMovement playerScript;
    ParticleSystem hit;
    ParticleSystem.EmissionModule isHitting;

    void Awake ()
    {
        hit = GetComponent<ParticleSystem>();
        isHitting = hit.emission;
        isHitting.enabled = false;
    }
    
    // Use this for initialization
	void Start ()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void PowEffectOn ()
    {
        isHitting.enabled = true;
    }

    void PowEffectOff()
    {
        isHitting.enabled = false;
    }
}
