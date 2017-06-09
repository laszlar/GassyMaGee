using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyPlank : MonoBehaviour {

    public GameObject daddyPlank;

    // Use this for initialization
	void Start ()
    {
        daddyPlank = GameObject.Find("DaddyPlank");
        this.transform.parent = daddyPlank.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
