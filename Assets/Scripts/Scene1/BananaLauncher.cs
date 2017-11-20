using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaLauncher : MonoBehaviour
{
    public GameObject player;
    public GameObject banana;
    BananaPowerup bananaPowerupScript;

    public float initSpawn = 20.0f;
    public float continuousSpawn = 20.0f;
    

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        bananaPowerupScript = gameObject.GetComponent<BananaPowerup>();

        InvokeRepeating("CheckOutThatBanana", initSpawn, continuousSpawn);	
	}

    void CheckOutThatBanana()
    {
        Instantiate(banana, new Vector2(6.0f, -0.488f), transform.rotation);
    }
}
