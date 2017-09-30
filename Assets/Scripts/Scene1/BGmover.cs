using UnityEngine;
using System.Collections;

public class BGmover : MonoBehaviour
{
    public float moveSpeed;
    PlayerMovement playerScript;

    private void Start()
    {

    }
    private void FixedUpdate()
    {
        transform.Translate((-moveSpeed * Time.deltaTime), 0f, 0f);
    }
}
