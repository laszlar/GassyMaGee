using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaLauncher : MonoBehaviour
{
    public GameObject player;
    public GameObject banana;
    BananaPowerup bananaPowerupScript;

    public float offset;

    public float initSpawn = 20.0f;
    public float continuousSpawn = 20.0f;
    private float bananaSpawnLocation;
    
    Vector2 playerPos;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        bananaPowerupScript = gameObject.GetComponent<BananaPowerup>();

        InvokeRepeating("CheckOutThatBanana", initSpawn, continuousSpawn);	
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerPos.x = player.transform.position.x;

        bananaSpawnLocation = playerPos.x + offset;
	}

    void CheckOutThatBanana()
    {
        Instantiate(banana, new Vector2(bananaSpawnLocation, -0.484f), transform.rotation);
    }
}
