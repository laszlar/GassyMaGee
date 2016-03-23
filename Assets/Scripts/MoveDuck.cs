using UnityEngine;
using System.Collections;

public class MoveDuck : MonoBehaviour
{

    public int duckSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(duckSpeed * Time.deltaTime, 0f, 0f);
    }
}
