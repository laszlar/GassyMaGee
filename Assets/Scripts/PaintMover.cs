using UnityEngine;
using System.Collections;

public class PaintMover : MonoBehaviour {

    public float paintSpeed;
    
    
    // Use this for initialization
	void Start ()
    {
   
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(paintSpeed * Time.deltaTime,0f, 0f);
	}


}
