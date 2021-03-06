﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    //Array
    private string[] creditsList;

    //GameObject
    private Text gOText;
    ImageChange swap;
    private GameObject finalText;

    //scripts
    CameraFilterPack_TV_Old_Movie_2 camFilter;
    //bool
    private bool hasLoaded;
    private bool startStopTimer = true;
    private bool changeCreditsFlag;

    //int
    private int orderOfCredits;

    //float
    private float timer;

	void Start ()
    {
        //initialize the string with our credits! 
        creditsList = new string[] {"Designer/Programmer\n Laszlo Kecskes", "Art/Animation Director\n Ludmila Sosa",
                                    "Senior Programmer\n Anthony Michelizzi", "Composer\n Cale Reneau", "Sounds", "vyzkov\n Duck 'Quack'",
                                    "thanvannispen\n 'Woman Sceaming'", "noctaro\n 'Small Dog Bark 01'", "CGEffex\n 'Ship artillery blast classic'",
                                    "InspectorJ\n Wind Chimes", "Benboncan\n Cow 'Moo'"};

        //find the text game object
        gOText = GameObject.Find("CreditsText").GetComponent<Text>();

        //find the image swap for the credits
        swap = GameObject.Find("FinalCredits").GetComponent<ImageChange>();

        //find the special thank you text and disable it
        finalText = GameObject.Find("FinalText");
        finalText.SetActive(false);

        //find the Camera effect 
        camFilter = GameObject.Find("Main Camera").GetComponent<CameraFilterPack_TV_Old_Movie_2>();

        //set text load to false on start
        hasLoaded = false;

        orderOfCredits = 0;
	}


    void Update()
    {
        ////////////////////////////////////
        //need to finalize the credits list!
        ////////////////////////////////////
        if (!hasLoaded)
        {

            if (startStopTimer)
            timer += Time.deltaTime;

            //display the credit for about 1.8 seconds and have a blank screen for 0.2 seconds
            if (timer > 0.2f && timer < 2.0f)
            {
                gOText.text = creditsList[orderOfCredits];
            }

            //turn off the credits after it reaches its final credit
            if (timer >= 2.0f && orderOfCredits == 10)
            {
                gOText.text = "";
                timer = 0f;
                startStopTimer = false;
                swap.swapImage = true;
                finalText.SetActive(true);
                camFilter.enabled = false;
            }

            //change to the next credit after 2 seconds
            if (timer >= 2.0f)
            {
                gOText.text = "";

                if (orderOfCredits < 10)
                {
                    orderOfCredits++;
                }
                timer = 0f;
            }
        }
    }
}
