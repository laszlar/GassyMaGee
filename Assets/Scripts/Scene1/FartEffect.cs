/*
Particle Effect system 
for Gassy's farts.
!Attached to particle effect!
*/

using UnityEngine;
using System.Collections;

public class FartEffect : MonoBehaviour
{
    public ParticleSystem constantlyFarting;
    public ParticleSystem.EmissionModule fart;
    public float timer;
    PlayerMovement player;

    void Awake()
    {
        NotFarting();
    }

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        CheckInput();
        Farted();
        SubtractTimer();
	}

    void CheckInput()
    {
        //fart less if you hit that banana
        if (player.bananaEnabled)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                timer += 0.05f;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                timer += 0.3f;
            }
        }
    }

    void Farted()
    {
        //activate that fart if more than 0 seconds.
        constantlyFarting = GetComponent<ParticleSystem>();
        fart = constantlyFarting.emission;      
        fart.enabled = (timer > 0) ? true : false;
    }

    void SubtractTimer()
    {
        //Subtract one second from the timer, and set it to zero if less than one second
        timer -= Time.deltaTime;
        timer = (timer <= 0) ? 0 : timer;
    }

    //turns farting off completely
    void NotFarting ()
    {
        constantlyFarting = GetComponent<ParticleSystem>();
        fart = constantlyFarting.emission;
        fart.enabled = false;
    }
}
