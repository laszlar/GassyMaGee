using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartFromLeaderboard : MonoBehaviour
{
    //bool
    private bool tapped;

    //Async
    AsyncOperation loadnow;

    private void Start()
    {
        tapped = false;
        StartCoroutine(LoadGameScene());
    } 
    public void LoadScene()
    {
        tapped = true;
    }

    IEnumerator LoadGameScene()
    {
        loadnow = SceneManager.LoadSceneAsync("Scene1");
        loadnow.allowSceneActivation = false;
        while (!loadnow.isDone)
        {
            if (tapped)
                loadnow.allowSceneActivation = true;

            yield return null;
        }
    }
}
