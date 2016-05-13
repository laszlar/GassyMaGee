﻿using UnityEngine;
using System.Collections;

public class PowEffect : MonoBehaviour
{
    PlayerMovement playerScript;
    ParticleSystem hit;
    ParticleSystem.EmissionModule isHitting;
    float delayPowTime = 0.3f;

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
       /* if (playerScript.punch)
        {
            PowEffectOn();
        }

        if(playerScript.punch == false)
        {
            isHitting.enabled = false;
        }*/
	}

    void PowEffectOn ()
    {
        isHitting.enabled = true;
    }

    void OnCollisionEnter2D (Collider2D coll)
    {
        if (playerScript.godMode && coll.gameObject.tag == "Enemy")
        {
            PowEffectOn();
        }
    }
}
