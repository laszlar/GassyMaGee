using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void LoadScene ()
    {
	    if (Input.GetKeyDown (KeyCode.Mouse0))
        {
            SceneManager.LoadScene("Scene1");
        }
	}
}
