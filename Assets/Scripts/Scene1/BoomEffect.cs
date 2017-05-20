using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{
    Bomb bombScript;
    ParticleSystem boomEffect;

    void Start()
    {
        bombScript = transform.parent.GetComponent<Bomb>();
        boomEffect = GetComponent<ParticleSystem>();
        boomEffect.Pause();
    }

    void Update()
    {
        if (bombScript.playerHitBomb)
        {
            boomEffect.Play();
        }
    }
}
