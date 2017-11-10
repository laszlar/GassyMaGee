using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour
{

#if UNITY_EDITOR

    private void Update()
    {
        gameObject.SetActive(true);
    }

#endif

    public void Quit()
    {
        Application.Quit();
    }


}
