using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    //Array
    private string[] creditsList;

    //GameObject
    private Text gOText;


	void Start ()
    {
        //initialize the string with our credits! 
        creditsList = new string[] {"Designer/Programmer\n Laszlo K", "Art/Animation Director\n Ludmila Sosa",
                                    "Senior Programmer\n Anthony Michelizzi", "Composer\n Cale Reneau"};

        //find the text game object
        gOText = GameObject.Find("Text").GetComponent<Text>();
	}
	

	void Update ()
    {
        gOText.text = creditsList[3];
	}
}
