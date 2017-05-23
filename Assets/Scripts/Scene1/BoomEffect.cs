using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{
    Bomb bombScript;
    public GameObject bomb;
    ParticleSystem boomEffect;

    float zValue = 0f;

    void Start()
    {
        bombScript = transform.parent.GetComponent<Bomb>();
        bomb = transform.parent.gameObject;
        boomEffect = GetComponent<ParticleSystem>();
        boomEffect.Pause();
    }

    void Update()
    {
        if (bombScript.playerHitBomb)
        {
            boomEffect.Play();
            if (transform.position.z != 0)
            {
                transform.position = new Vector3(bomb.transform.position.x, bomb.transform.position.y, zValue);
            }
        }
    }
}
