using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpin : MonoBehaviour
{
    public float spinSpeed;
    private float uppersAndDowners;
    private float randomHeight;
    Vector3 moveLeft;

	// Use this for initialization
	void Start () {
		
	}
	
    void FixedUpdate()
    {
        /*randomHeight = Random.Range(0, 1);
        uppersAndDowners = Mathf.PingPong(Time.time, 0.5f);

        //moveLeft = new Vector3((-1 * Time.deltaTime), -uppersAndDowners, 0f);

        //you can use this line of code with transform.rotate, must use += operator
        //transform.position += moveLeft;
        */
              
        //rotate the wave on its Z axis
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}
