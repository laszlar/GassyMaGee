using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //Variables are for generating the waves in a list continuously
    public GameObject wavePrefab;
    private GameObject wavingIt;
    private Transform waveAsset;
    private float waveSize;
    private Vector2 startPosition = new Vector2(0.55f, -1.39f);
    private Vector2 newPosition;
    public static List<GameObject> Waves = new List<GameObject>();

    void Start ()
    {
        ResetList();
        //Making the waves generate in the list and so forth
        //List<GameObject> Waves = new List<GameObject>();
        waveAsset = wavePrefab.transform.Find("WaveArt");
        waveSize = waveAsset.GetComponent<Renderer>().bounds.size.x;
        wavingIt = Instantiate(wavePrefab, startPosition, Quaternion.identity);
        newPosition = wavingIt.transform.position;
        newPosition.x += (0.75f * waveSize);
        Waves.Add(wavingIt);
    }
	
	void Update ()
    {
        //Make those waves spawn yo!
        Spawn();
    }

    void Spawn()
    {
        //This is where the info goes to add to the list and such
        if (Waves.Count < 16)
        {
            wavingIt = Instantiate(wavePrefab, newPosition, Quaternion.identity);
            newPosition = wavingIt.transform.position;
            newPosition.x += (0.75f * waveSize);
            Waves.Add(wavingIt);
        }
    }

    void ResetList()
    {
        if (Waves.Count != 0)
            Waves.Clear();
    }
}
