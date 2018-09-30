using UnityEngine;
using UnityEngine.UI;

public class UserPrefab : MonoBehaviour {

    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text scoreText;

    public void Setup (User _user, int _rank)
    {
        nameText.text = _rank + "-" + _user.name;
        scoreText.text = _user.score.ToString("n0");
    }
}