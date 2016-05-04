using UnityEngine;
using System.Collections;

public class FartEffect : MonoBehaviour
{
    public ParticleSystem.EmissionModule fart;
    public float timer;

    void Start()
    {
        fart.enabled = false;
    }

	void Update ()
    {
        CheckInput();
        Farted();
        SubtractTimer();
	}

    void CheckInput()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            //we shall see if this works.
            timer += 0.25f;
        }
    }

    void Farted()
    {
        //activate that fart if more than 0 seconds.
        fart.enabled = (timer > 0) ? true : false;
    }

    void SubtractTimer()
    {
        //Subtract one second from the timer, and set it to zero if less than one second
        timer -= Time.deltaTime;
        timer = (timer <= 0) ? 0 : timer;
    }
}
