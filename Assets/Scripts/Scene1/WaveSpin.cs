using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpin : MonoBehaviour
{
    public float spinSpeed;
    private SpriteRenderer waveSprite;
    WaveSpawner waveScript;


    private void Start()
    {
        waveSprite = GetComponent<SpriteRenderer>();
        waveScript = GameObject.Find("WaveMover").GetComponent<WaveSpawner>();
        for (int x = 0; x < 4; x++)
        {
            if (waveScript.order[x] < 0 || waveScript.order[x] > 3)
            {
                return;
            }
            else
            {
                if (waveScript.order[x] == 0)
                {
                    waveSprite.sortingOrder = 0;
                }

                if (waveScript.order[x] == 1)
                {
                    waveSprite.sortingOrder = 1;
                }

                if (waveScript.order[x] == 2)
                {
                    waveSprite.sortingOrder = 2;
                }

                if (waveScript.order[x] == 3)
                {
                    waveSprite.sortingOrder = 3;
                }
            }
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}
