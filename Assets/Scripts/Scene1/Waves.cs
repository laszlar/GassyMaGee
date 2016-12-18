using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

    #region Variables
    public float widthOfThisObject;
    public int numOfBGObjects;
    float newPos;

    public float slowWaves;
    #endregion

    void Update()
    {
        transform.Translate(slowWaves * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Looper")
        {
            newPos = widthOfThisObject * numOfBGObjects;
            transform.Translate(Vector2.right * newPos, 0);
        }
    }
}
