using Firebase.Database;
using Firebase;
using Firebase.Unity.Editor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LeaderboardManager : MonoBehaviour {

    [SerializeField]
    private Transform parent;

    [SerializeField]
    private GameObject playerPrefab;

    public static LeaderboardManager instance; //singleton

    private DatabaseReference dbReference;

    //score variable
    private int actualScore;

    private void Awake ()
    {
        instance = this;
        actualScore = PlayerPrefs.GetInt("HighScore");
    }

    void Start ()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://gassy-6e5e9.firebaseio.com/");
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

        GetLeaderboard();
    }

    public void SaveScoreToLeaderboard (string _name, int actualScore) //use this method to save user's score
    {
        User m_user = new User(_name, actualScore);
        string m_json = JsonUtility.ToJson(m_user);

        dbReference.Child("leaderboard").Child(_name).SetRawJsonValueAsync(m_json);
    }

    public void GetLeaderboard () //you can use this method to call the leaderboard
    {
        List<User> m_userList = new List<User>();

        FirebaseDatabase.DefaultInstance
        .GetReference("leaderboard")
        .GetValueAsync().ContinueWith(task => {
        if (task.IsFaulted)
        {
            Debug.Log("Having trouble getting leaderboard");
        }
        else if (task.IsCompleted)
        {
            DataSnapshot snapshot = task.Result;
            foreach (var childSnapshot in snapshot.Children)
            {
                User user = JsonUtility.FromJson<User>(childSnapshot.GetRawJsonValue());
                m_userList.Add(user);        
            }
        }
            ShowPlayers(m_userList.OrderByDescending(x => x.score).ToList());
        });
    }

    void ShowPlayers (List<User> _leaderboard)
    {
        for (int i = 0; i < _leaderboard.Count; i++)
        {
            GameObject m_prefabGO = Instantiate(playerPrefab, parent);
            UserPrefab m_prefab = m_prefabGO.GetComponent<UserPrefab>();

            m_prefab.Setup(_leaderboard[i], i + 1);
        }
    }
}

public class User
{
    public string name;

    public int score;

    public User ()
    {

    }

    public User (string _name, int _score)
    {
        this.name = _name;
        this.score = _score;
    }
}