using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FattyCannon : MonoBehaviour {

    private float _delay = 30f;
    private float _rate = 20f;
    private float _offset = 5f;
    [SerializeField]
    private GameObject _fattyFatty;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Spawn", _delay, _rate);
	}

    private void Spawn()
    {
        Instantiate(_fattyFatty, new Vector2(6.0f, Random.Range(-0.275f, 2)), Quaternion.identity);
    }
}
