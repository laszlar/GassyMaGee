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
    private Vector2 startPosition0 = new Vector2(-0.50f, -1.39f);
    private Vector2 startPosition1 = new Vector2(-0.30f, -1.59f);
    private Vector2 startPosition2 = new Vector2(-0.10f, -1.79f);
    private Vector2 newPosition0;
    private Vector2 newPosition1;
    private Vector2 newPosition2;
    public static List<GameObject> Waves0 = new List<GameObject>();
    public static List<GameObject> Waves1 = new List<GameObject>();
    public static List<GameObject> Waves2 = new List<GameObject>();

    void Start ()
    {
        ResetList();
        InitiateSpawn0();
        InitiateSpawn1();
        InitiateSpawn2();
    }
	
	void Update ()
    {
        //Make those waves spawn yo!
        Spawn0();
        Spawn1();
        Spawn2();
    }

    void InitiateSpawn0()
    {
        //Making the waves generate in the list and so forth
        //List<GameObject> Waves = new List<GameObject>();
        waveAsset = wavePrefab.transform.Find("WaveArt");
        waveSize = waveAsset.GetComponent<Renderer>().bounds.size.x;
        wavingIt = Instantiate(wavePrefab, startPosition0, Quaternion.identity);
        newPosition0 = wavingIt.transform.position;
        newPosition0.x += (0.75f * waveSize);
        Waves0.Add(wavingIt);
    }

    void InitiateSpawn1()
    {
        waveAsset = wavePrefab.transform.Find("WaveArt");
        waveSize = waveAsset.GetComponent<Renderer>().bounds.size.x;
        wavingIt = Instantiate(wavePrefab, startPosition1, Quaternion.identity);
        newPosition1 = wavingIt.transform.position;
        newPosition1.x += (0.75f * waveSize);
        Waves1.Add(wavingIt);
    }

    void InitiateSpawn2()
    {
        waveAsset = wavePrefab.transform.Find("WaveArt");
        waveSize = waveAsset.GetComponent<Renderer>().bounds.size.x;
        wavingIt = Instantiate(wavePrefab, startPosition2, Quaternion.identity);
        newPosition2 = wavingIt.transform.position;
        newPosition2.x += (0.75f * waveSize);
        Waves2.Add(wavingIt);
    }

    void Spawn0()
    {
        //This is where the info goes to add to the list and such
        if (Waves0.Count < 15)
        {
            wavingIt = Instantiate(wavePrefab, newPosition0, Quaternion.identity);
            newPosition0 = wavingIt.transform.position;
            newPosition0.x += (0.75f * waveSize);
            Waves0.Add(wavingIt);
        }
    }

    void Spawn1()
    {
        if (Waves1.Count < 15)
        {
            wavingIt = Instantiate(wavePrefab, newPosition1, Quaternion.identity);
            newPosition1 = wavingIt.transform.position;
            newPosition1.x += (0.75f * waveSize);
            Waves1.Add(wavingIt);
        }
    }

    void Spawn2()
    {
        if (Waves2.Count < 15)
        {
            wavingIt = Instantiate(wavePrefab, newPosition2, Quaternion.identity);
            newPosition2 = wavingIt.transform.position;
            newPosition2.x += (0.75f * waveSize);
            Waves2.Add(wavingIt);
        }
    }

    void ResetList()
    {
        if (Waves0.Count != 0 || Waves1.Count != 0 || Waves2.Count != 0)
        {
            Waves0.Clear();
            Waves1.Clear();
            Waves2.Clear();
        }
    }
}
