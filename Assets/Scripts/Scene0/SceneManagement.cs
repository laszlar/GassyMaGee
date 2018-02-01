using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour {

    private bool _loadScene = false;
    private string _scene = "Scene1";
    [SerializeField] private Text _loadingText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (!_loadScene)
        {
            _loadScene = true;
            _loadingText.text = "Loading...";
            StartCoroutine(LoadNewScene());
        }

        if (_loadScene)
        {
            _loadingText.color = new Color(_loadingText.color.r, _loadingText.color.g, 
                _loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }
	}

    IEnumerator LoadNewScene()
    {
        // This might be a bit much? seems fine for now.
        yield return new WaitForSeconds(5);

        AsyncOperation async = SceneManager.LoadSceneAsync(_scene, LoadSceneMode.Additive);
        async.allowSceneActivation = false;
        
        while (async.progress < 0.9f)
        {
            yield return null;
        }

        async.allowSceneActivation = true;
    }
}
