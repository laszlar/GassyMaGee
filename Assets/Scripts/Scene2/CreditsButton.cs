using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    //load that scene!
    public void LoadScene()
    {
        SceneManager.LoadScene("Credits");
    }
}
