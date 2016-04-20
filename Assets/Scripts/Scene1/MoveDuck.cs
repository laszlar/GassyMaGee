using UnityEngine;
using System.Collections;

public class MoveDuck : MonoBehaviour
{

    public int duckSpeed;
    public float halfDuckSpeed;
    PlayerMovement script;

    // Use this for initialization
    void Start()
    {
        script = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!script.duckThing)
        {
            Debug.Log("i'm  coming");
            transform.Translate(duckSpeed * Time.deltaTime, 0f, 0f);
        }
        else 
        {
            Debug.Log("I'm moving half speed");
            transform.Translate(halfDuckSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}
