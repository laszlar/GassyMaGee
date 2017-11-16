using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostDestroyer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fuckingPostsAndRope")
        {
            Destroy(collision.gameObject);
            MovePostsRopeBG._allTheFuckingRopeThings.RemoveAt(0);
        }
    }
}
