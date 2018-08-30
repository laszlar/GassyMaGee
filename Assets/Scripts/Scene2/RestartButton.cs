using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartButton : MonoBehaviour
{
    //Async
    AsyncOperation load;

    //boolean
    private bool haveTapped = false;

    private void Start()
    {
        StartCoroutine(LoadSceneNow());
    }

    public void LoadScene()
    {
        haveTapped = true;
        //SceneManager.LoadScene("Scene1");
    }

    IEnumerator LoadSceneNow()
    {
        load = SceneManager.LoadSceneAsync("Scene1");
        load.allowSceneActivation = false;
        while (!load.isDone)
        {
            if (haveTapped)
                load.allowSceneActivation = true;
            yield return null;
        }
    }
}
