using UnityEngine;
using System.Collections;

public class GroundMover : MonoBehaviour {

    public float speed;

    void FixedUpdate ()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }
}
