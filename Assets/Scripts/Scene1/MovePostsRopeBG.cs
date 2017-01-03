using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePostsRopeBG : MonoBehaviour
{
	public GameObject PostsAndFuckingRope;
	private GameObject _fuckingObject;
	private readonly Vector2 _startPosition = new Vector2(10.94f, -0.774f);
	private Vector2 _newSpawnPosition;
	private float _offset;

	public static List<GameObject> _allTheFuckingRopeThings = new List<GameObject>();

	private void Start()
	{
		ResetStaticVars();
		_offset = PostsAndFuckingRope.GetComponent<Renderer> ().bounds.size.x;
		_fuckingObject = Instantiate(PostsAndFuckingRope, _startPosition, Quaternion.identity);
		_newSpawnPosition = _fuckingObject.transform.position;
		_newSpawnPosition.x += _offset;
		_allTheFuckingRopeThings.Add(_fuckingObject);
	}
	// Update is called once per frame
	private void Update()
	{
		Spawn();
	}
	private void Spawn()
	{
		if (_allTheFuckingRopeThings.Count < 10)
		{
			_fuckingObject = Instantiate(PostsAndFuckingRope, _newSpawnPosition, Quaternion.identity);        //spawn bitches.
			_newSpawnPosition = _fuckingObject.transform.position;
			_newSpawnPosition.x += _offset;
			_allTheFuckingRopeThings.Add(_fuckingObject);
		}
	}

	private void ResetStaticVars() {
		_allTheFuckingRopeThings.Clear();
	}
}

