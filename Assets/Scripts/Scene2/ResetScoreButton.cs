using UnityEngine;
using System.Collections;

public class ResetScoreButton : MonoBehaviour {

	public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
