using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTapAnimation : MonoBehaviour
{
    //boolean 
    public bool hasTapped;

	// Use this for initialization
	void Start () {
        hasTapped = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasTapped && Input.GetMouseButton(0))
            Destroy(gameObject);
        else
            return;
	}
}
