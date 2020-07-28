using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* recently added the bomb power up, why that was missing from the game 
 * is entirely beyond me */

public class PowerUpManager : MonoBehaviour
{
    //GameObjects
    public GameObject paintCan, parachute, banana, cameraPowerUp, bombMaster;

    //Scripts
    PlayerMovement playerScript;
    AdsButton adsScript;

    //Array
    private GameObject[] powerUpHolder;

    //Vector Positions
    private Vector2 spawnPOS;

    //float 
    private float basicTimer;
    private float paintTimer;
    private float checkPlayerScriptTimer;
    private float adsTimer;

    //bool
    private bool spawnBasics;
    private bool spawnPaint;
    private bool elongateStartTime;
    private bool doOnlyOnce;
    private bool doTimerOnce;

    private void Start()
    {
        //find the player script
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();

        //Initiate the array
        powerUpHolder = new GameObject[] { parachute, cameraPowerUp, bombMaster, paintCan };

        //initialize the boolean
        spawnBasics = false;
        spawnPaint = false;
        elongateStartTime = false;
        doOnlyOnce = false;
        doTimerOnce = true;

        //initialize floats
        basicTimer = 0f;
        paintTimer = 0f;
    }

    private void Update()
    {
        //if watched ad, launch a random power up!
        if (AdsButton.watchedVideo)
        {
            adsTimer += Time.deltaTime;
            if (adsTimer >= 4.0)
            {
                spawnBasics = true;
                adsTimer = 0f;
                AdsButton.watchedVideo = false;
            }
        }

        //run the timer to check player Script
        if (doTimerOnce)
            checkPlayerScriptTimer += Time.deltaTime;

        //run those timers!
        basicTimer += Time.deltaTime;
        paintTimer += Time.deltaTime;

        //if player receives paint can on start (watched ad) extend the timer once to prevent cheating
        if (checkPlayerScriptTimer <= 8.0f && playerScript.godMode && !doOnlyOnce)
            elongateStartTime = true;

        if (elongateStartTime)
        {
            paintTimer += 10.0f;
            elongateStartTime = false;
            doOnlyOnce = true;
        }

        if (basicTimer >= 10.0f)
            spawnBasics = true;
        

        if (paintTimer >= 45.0f)
        {
            spawnPaint = true;
            doTimerOnce = false;
        }  

        if (spawnBasics)
        {
            Instantiate(powerUpHolder[Random.Range(0, 2)], new Vector2(5.0f, Random.Range(-0.4f, 1.2f)), Quaternion.identity);
            spawnBasics = false;
            basicTimer = 0f;
        }

        if (spawnPaint)
        {
            Instantiate(powerUpHolder[3], new Vector2(5.0f, Random.Range(-0.4f, 1.0f)), Quaternion.identity);
            spawnPaint = false;
            //reset the paint timer
            paintTimer = 0f;
        }
    }

}
