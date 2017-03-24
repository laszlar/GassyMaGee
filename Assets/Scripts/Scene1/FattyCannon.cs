using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FattyCannon : MonoBehaviour {

    private float _delay = 30f;
    private float _rate = 20f;
    private float _offset = 5f;
    private float _spawnLocation;
    [SerializeField]
    private GameObject _fattyFatty;
    [SerializeField]
    private GameObject _player;
    private Vector2 _playerPos;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", _delay, _rate);
	}
	
	// Update is called once per frame
	void Update () {
        _playerPos.x = _player.transform.position.x;
        _spawnLocation = _playerPos.x + _offset;
    }

    private void Spawn()
    {
        Instantiate(_fattyFatty, new Vector2(_spawnLocation, Random.Range(-0.7f, 1)), Quaternion.identity);
    }
}
