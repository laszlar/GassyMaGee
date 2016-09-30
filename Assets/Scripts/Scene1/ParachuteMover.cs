/*
Moves the parachute
!attached to the parachute prefab!
*/

using UnityEngine;
using System.Collections;

public class ParachuteMover : MonoBehaviour {

    public float parachuteSpeed;

	
	//move that Parachute!
	void Update ()
    {
        transform.Translate(parachuteSpeed * Time.deltaTime, 0f, 0f);
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

            if(player)
            {
                player.ParachuteMethod();
            }
        }
    }
}
