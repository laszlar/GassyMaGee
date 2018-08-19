using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTapAnimation : MonoBehaviour
{
    //boolean 
    public bool hasTapped;
    private int alreadyPlayedTapTap = 0;

	// Use this for initialization
	void Start ()
    {
        alreadyPlayedTapTap = PlayerPrefs.GetInt("IPlayedTapTapAnimation");

        //delete this game object if it's already shown
        if (alreadyPlayedTapTap == 1)
            Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (alreadyPlayedTapTap == 0 && Input.GetMouseButton(0))
        {
            alreadyPlayedTapTap = 1;
            PlayerPrefs.SetInt("IPlayedTapTapAnimation", alreadyPlayedTapTap);
            Destroy(gameObject);
        }
	}


}
