using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomStrings : MonoBehaviour
{
    public Text thisText;
    string[] randomText = new string[] {"Oh, my miserable fate!", "I guess this is how it had to go...", "Better luck next time!",
                                         "This is how the cookie crumbles!", "Let this not be the end!", "Oh, no!", "I'll get home one day!"}; 
	
	void Start ()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        thisText = this.GetComponent<Text>();
        thisText.text = randomText[(Random.Range(0, 6))];
	}
}
