using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{

	public void LoadScene ()
    {
        SceneManager.LoadScene("Scene1");
    }
}
