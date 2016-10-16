using UnityEngine;
using System.Collections;

public class BGmover : MonoBehaviour
{

    public float widthOfThisObject;
    public int numOfBGObjects;
    float newPos; 

	void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Looper")
        {
            newPos = widthOfThisObject * numOfBGObjects;
            transform.Translate(Vector2.right * newPos, 0);
        }
    }
}
