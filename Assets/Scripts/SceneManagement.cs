using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Time.timeSinceLevelLoad >= 5f || Input.GetKeyDown (KeyCode.Mouse0))
        {
            SceneManager.LoadScene("Scene1");
        }
	}
}
