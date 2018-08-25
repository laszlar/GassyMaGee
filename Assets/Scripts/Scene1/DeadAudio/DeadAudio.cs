using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAudio : MonoBehaviour {

    AudioSource sadTrombone;
    public AudioClip dead;

    //Get Player Data
    PlayerMovement playerScript;

    private void Start()
    {
        sadTrombone = GetComponent<AudioSource>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (playerScript.dead)
            sadTrombone.PlayOneShot(dead, 0.5f);
	}
}
