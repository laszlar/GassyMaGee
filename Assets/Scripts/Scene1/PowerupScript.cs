/*
Enables God Mode.
!Attached to Paint Prefab!
*/

using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {

	public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            Destroy(gameObject);

            if (player)
            {
                player.SetInvincible();
            }
        }
    }
}
