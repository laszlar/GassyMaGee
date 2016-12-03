using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgbgMover : MonoBehaviour {

    public float widthOfThisObject;
    public int numOfBGObjects;
    float newPos;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Looper")
        {
            newPos = (widthOfThisObject * numOfBGObjects)/4;
            transform.Translate(Vector2.right * newPos, 0);
        }
    }
}
