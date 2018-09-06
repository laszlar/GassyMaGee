using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

/* It's kinda strange that I put this script on the Restart button
 * We could probably just create another game object (empty) to take
 * care of of this, but it works this way, so I'll leave this alone 
 * for now. 
 */

public class RestartButton : MonoBehaviour
{
    //Async
    AsyncOperation load;

    //boolean
    private bool haveTapped = false;

    //text (loading)
    //public Text loadingText;

    //Gameobject
    [SerializeField]
    private GameObject gassyLoading;

    private void Start()
    {
        StartCoroutine(LoadSceneNow());
        //loadingText.text = "Loading...";
    }

    private void Update()
    {
        gassyLoading.SetActive(true);

        //loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b,
            //Mathf.PingPong(Time.time * 1.5f, 1));
    } 

    public void LoadScene()
    {
        haveTapped = true;
    }

    IEnumerator LoadSceneNow()
    {
        yield return new WaitForSeconds(2);

        load = SceneManager.LoadSceneAsync("Scene1");
        load.allowSceneActivation = false;
        while (!load.isDone)
        {
            if (load.progress >= 0.90f)
                gassyLoading.SetActive(false);

            if (haveTapped)
                load.allowSceneActivation = true;
            yield return null;
        }
    }
}
