using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    //GameObjects
    public GameObject paintCan, parachute, banana;

    //player script
    PlayerMovement playerScript;

    //Array
    private GameObject[] powerUpHolder;

    //Vector Positions
    private Vector2 spawnPOS;

    //float 
    private float basicTimer;
    private float paintTimer;
    private float checkPlayerScriptTimer;


    //bool
    private bool spawnBasics;
    private bool spawnPaint;
    private bool elongateStartTime;
    private bool doOnlyOnce;
    private bool doTimerOnce;

    private void Start()
    {
        //Initiate the array
        powerUpHolder = new GameObject[] { parachute, banana, paintCan };

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
        //run the timer to check player Script
        if (doTimerOnce)
            checkPlayerScriptTimer += Time.deltaTime;

        //run those timers!
        basicTimer += Time.deltaTime;
        paintTimer += Time.deltaTime;

        if (checkPlayerScriptTimer >= 1.0f && playerScript.godMode && !doOnlyOnce)
            elongateStartTime = true;

        if (elongateStartTime)
        {
            basicTimer -= 5.0f;
            elongateStartTime = false;
            doOnlyOnce = true;
        }

        if (basicTimer >= 10.0f)
            spawnBasics = true;
        

        if (paintTimer >= 20.0f)
        {
            spawnPaint = true;
            doTimerOnce = false;
        }
            

        if (spawnBasics)
        {
            Instantiate(powerUpHolder[Random.Range(0, 1)], new Vector2(5.0f, Random.Range(-0.4f, 1.2f)), Quaternion.identity);
            spawnBasics = false;
            basicTimer = 0f;
        }

        if (spawnPaint)
        {
            Instantiate(powerUpHolder[2], new Vector2(5.0f, Random.Range(-0.4f, 1.0f)), Quaternion.identity);
            spawnPaint = false;
            paintTimer = 0f;
        }
    }

}
