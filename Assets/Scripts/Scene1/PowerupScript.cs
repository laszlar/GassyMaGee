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
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
