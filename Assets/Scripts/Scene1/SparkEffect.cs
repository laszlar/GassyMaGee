using System.Collections;
using UnityEngine;

public class SparkEffect : MonoBehaviour
{
    Bomb bombScript;

	void Start ()
    {
        bombScript = transform.parent.GetComponent<Bomb>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (bombScript.playerHitBomb)
        {
            SparkEffectOff();
        }
	}

    void SparkEffectOff()
    {
        gameObject.SetActive(false);
    }
}
