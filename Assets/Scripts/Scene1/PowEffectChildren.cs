/*
See pow effect.
Same thing here. 
Tried to implement...
*/

using UnityEngine;
using System.Collections;

public class PowEffectChildren : MonoBehaviour
{

    PlayerMovement playerScript;
    ParticleSystem hit;
    ParticleSystem.EmissionModule isHitting;
    float delayPowTime = 0.3f;

    void Awake()
    {
        hit = GetComponent<ParticleSystem>();
        isHitting = hit.emission;
        isHitting.enabled = false;
    }

    // Use this for initialization
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PowEffectOnC ()
    {
        isHitting.enabled = true;
    }

    void DelayPow ()
    {
        isHitting.enabled = false;
        Invoke("PowEffectOnC", delayPowTime);
    }
}
