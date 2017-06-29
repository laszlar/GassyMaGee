using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpin : MonoBehaviour
{
    public float spinSpeed;

    void FixedUpdate()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}
