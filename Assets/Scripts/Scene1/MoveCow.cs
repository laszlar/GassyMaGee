/*
Not in use!
*/

using UnityEngine;
using System.Collections;

public class MoveCow : MonoBehaviour
{

    public int cowSpeed;
    public int spinSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(cowSpeed * Time.deltaTime, 0f, 0f);
    }
}