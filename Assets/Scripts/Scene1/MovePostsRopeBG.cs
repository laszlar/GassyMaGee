using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePostsRopeBG : MonoBehaviour
{
    public GameObject PostsAndFuckingRope;
    private GameObject _fuckingObject;
    private readonly Vector2 _startPosition = new Vector2(10.94f, -0.774f);
    private const float ObjectLife = 3.4f;
    private float _lifeElapsedTime;
    private const float TimeTillDestroy = 20f;
    private float _destroyElapsedTime;

    private readonly List<GameObject> _allTheFuckingRopeThings = new List<GameObject>();

    private void Start()
    {
        _fuckingObject = Instantiate(PostsAndFuckingRope, _startPosition, transform.rotation);
        _allTheFuckingRopeThings.Add(_fuckingObject);
    }
    // Update is called once per frame
    private void Update()
    {
        if (_allTheFuckingRopeThings.Count < 10)
        {
            Spawn();
        }

        if (_destroyElapsedTime < TimeTillDestroy)
        {
            _destroyElapsedTime += Time.deltaTime;
        }

        if (_allTheFuckingRopeThings.Count == 10 && _destroyElapsedTime >= TimeTillDestroy)
        {
            _lifeElapsedTime += Time.deltaTime;
            if (_lifeElapsedTime >= ObjectLife)
            {
                Destroy(_allTheFuckingRopeThings[0]);
                _allTheFuckingRopeThings.RemoveAt(0);
                _lifeElapsedTime = 0;
            }
        }
    }
    private void Spawn()
    {
        var offset = _fuckingObject.GetComponent<Renderer>().bounds.size.x;
        var newPosition = _fuckingObject.transform.position;
        newPosition.x += offset;
        _fuckingObject = Instantiate(PostsAndFuckingRope, newPosition, transform.rotation);        //spawn bitches.
        _allTheFuckingRopeThings.Add(_fuckingObject);
    }
}

