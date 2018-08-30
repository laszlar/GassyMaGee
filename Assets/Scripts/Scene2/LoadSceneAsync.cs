using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAsync : MonoBehaviour
{
    AsyncOperation load;

    //boolean
    private bool hasLoaded = false;

    private void Update()
    {
        if (!hasLoaded)
        {
            StartCoroutine(LoadSceneNow());
            hasLoaded = true;
        }
        
    }

    IEnumerator LoadSceneNow()
    {
        load = SceneManager.LoadSceneAsync("Scene1");

        while (!load.isDone)
            yield return null;
    }
}
