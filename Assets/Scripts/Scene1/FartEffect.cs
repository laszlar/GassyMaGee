using UnityEngine;
using System.Collections;

public class FartEffect : MonoBehaviour
{
    public ParticleSystem fart;

    void Start()
    {
       /* ParticleSystem fart = GetComponent<ParticleSystem>();
        ParticleSystem.EmissionModule isFarting = fart.emission;
        isFarting.enabled = false;
        //farting = GetComponent<ParticleSystem>().emission.enabled = false;
        //farting.enabled = false;*/
    }
	

	void Update ()
    {
	    if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            ParticleSystem fart = GetComponent<ParticleSystem>();
            ParticleSystem.EmissionModule isFarting = fart.emission;
            isFarting.enabled = true;
        }
        else
        {
            ParticleSystem fart = GetComponent<ParticleSystem>();
            ParticleSystem.EmissionModule isFarting = fart.emission;
            isFarting.enabled = false;
        }
	}
}
