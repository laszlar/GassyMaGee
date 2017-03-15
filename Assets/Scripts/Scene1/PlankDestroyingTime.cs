/*
Destroys the planks
!attached to plank destroyer!
Effectively also destroys the PostsandFuckingRopes my nigga v2.398398798359385398 @Tony
*/

using UnityEngine;
using System.Collections;

public class PlankDestroyingTime : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Plank")
        {
            Destroy(coll.gameObject);
            PlankSpawner.Planks.RemoveAt(0);
        }
		else if (coll.gameObject.tag == "fuckingPostsAndRope")
        {
		    Destroy (coll.gameObject);
			MovePostsRopeBG._allTheFuckingRopeThings.RemoveAt (0);
		}
    }
}
