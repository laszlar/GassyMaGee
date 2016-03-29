using UnityEngine;
using System.Collections;

public class PaintMover : MonoBehaviour {

    public float paintSpeed;

    public float amplitudeX = 10.0f;
    public float amplitudeY = 5.0f;
    public float omegaX = 1.0f;
    public float omegaY = 5.0f;
    float index;

    // Use this for initialization
    void Start ()
    {
   
	}
	
	// Update is called once per frame
	void Update ()
    {
        index += Time.deltaTime;
        float x = amplitudeX * Mathf.Cos(omegaX * index);
        float y = amplitudeY * Mathf.Sin(omegaY * index);
        transform.localPosition = new Vector3(x, y, 0);
    }


}
