using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour {

    Transform player;
    float offsetX;

	// Use this for initialization
	void Start () {
        GameObject player_go = GameObject.FindGameObjectWithTag("Player");  //this sets up player_go

            if(player_go == null)
        {
            Debug.LogError("Couldn't find an object with tag 'Player'!");  //in case unity can't find player
            return;
        }

        player = player_go.transform;

        offsetX = transform.position.x - player.position.x;
	}
	
	// Update is called once per frame
	void Update () {
      if(player != null)
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x + offsetX;
            transform.position = pos;
        }   
	}
}
