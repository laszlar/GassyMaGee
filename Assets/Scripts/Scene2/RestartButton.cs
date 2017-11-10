using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartButton : MonoBehaviour {

#if UNITY_EDITOR

    private void Update()
    {
        gameObject.SetActive(true);
    }

#endif

    // Update is called once per frame
    public void LoadScene()
    {
        SceneManager.LoadScene("Scene1");
    }
        
}
