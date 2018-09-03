using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    //Async
    AsyncOperation load;

    //boolean
    private bool haveTapped = false;

    //text (loading)
    public Text loadingText;

    private void Start()
    {
        StartCoroutine(LoadSceneNow());
        loadingText.text = "Loading...";
    }

    private void Update()
    {
        loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b,
            Mathf.PingPong(Time.time * 1.5f, 1));
    } 

    public void LoadScene()
    {
        haveTapped = true;
        //SceneManager.LoadScene("Scene1");
    }

    IEnumerator LoadSceneNow()
    {
        yield return new WaitForSeconds(2);

        load = SceneManager.LoadSceneAsync("Scene1");
        load.allowSceneActivation = false;
        while (!load.isDone)
        {
            if (load.progress >= 0.90f)
                loadingText.text = "";

            if (haveTapped)
                load.allowSceneActivation = true;
            yield return null;
        }
    }
}
