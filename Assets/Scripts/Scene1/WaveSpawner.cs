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
    private int waveOrder0;
    private int waveOrder1;
    private int waveOrder2;
    private int waveOrder3;
    private Vector2 startPosition0 = new Vector2(-0.50f, -1.39f);
    private Vector2 startPosition1 = new Vector2(-0.116f, -1.39f);
    private Vector2 startPosition2= new Vector2(-0.116f, -1.59f);
    private Vector2 startPosition3 = new Vector2(-0.3724f, -1.79f);
    private Vector2 newPosition0;
    private Vector2 newPosition1;
    private Vector2 newPosition2;
    private Vector2 newPosition3;
    public static List<GameObject> Waves0 = new List<GameObject>();
    public static List<GameObject> Waves1 = new List<GameObject>();
    public static List<GameObject> Waves2 = new List<GameObject>();
    public static List<GameObject> Waves3 = new List<GameObject>();

    void Start ()
    {
        ResetList();
        InitiateSpawn0();
        InitiateSpawn1();
        InitiateSpawn2();
        InitiateSpawn3();
    }
	
	void FixedUpdate ()
    {
        //Make those waves spawn yo!
        Spawn0();
        Spawn1();
        Spawn2();
        Spawn3();
    }

    void InitiateSpawn0()
    {
        //Making the waves generate in the list and so forth
        waveAsset = wavePrefab.transform.Find("WaveArt");
        waveSize = waveAsset.GetComponent<SpriteRenderer>().bounds.size.x;
        waveOrder0 = waveAsset.GetComponent<SpriteRenderer>().sortingOrder;
        wavingIt = Instantiate(wavePrefab, startPosition0, Quaternion.identity);
        newPosition0 = wavingIt.transform.position;
        newPosition0.x += waveSize;
        Waves0.Add(wavingIt);
    }

    void InitiateSpawn1()
    {
        //Making the waves generate in the list and so forth
        waveAsset = wavePrefab.transform.Find("WaveArt");
        waveSize = waveAsset.GetComponent<SpriteRenderer>().bounds.size.x;
        waveOrder1 = waveAsset.GetComponent<SpriteRenderer>().sortingOrder;
        wavingIt = Instantiate(wavePrefab, startPosition1, Quaternion.identity);
        newPosition1 = wavingIt.transform.position;
        newPosition1.x += waveSize;
        Waves1.Add(wavingIt);
    }


    void InitiateSpawn2()
    {
        waveAsset = wavePrefab.transform.Find("WaveArt");
        waveSize = waveAsset.GetComponent<SpriteRenderer>().bounds.size.x;
        waveOrder2 = waveAsset.GetComponent<SpriteRenderer>().sortingOrder;
        wavingIt = Instantiate(wavePrefab, startPosition2, Quaternion.identity);
        newPosition2 = wavingIt.transform.position;
        newPosition2.x += waveSize;
        Waves2.Add(wavingIt);
    }

    void InitiateSpawn3()
    {
        waveAsset = wavePrefab.transform.Find("WaveArt");
        waveSize = waveAsset.GetComponent<SpriteRenderer>().bounds.size.x;
        waveOrder3 = waveAsset.GetComponent<SpriteRenderer>().sortingOrder;
        wavingIt = Instantiate(wavePrefab, startPosition3, Quaternion.identity);
        newPosition3 = wavingIt.transform.position;
        newPosition3.x += waveSize;
        Waves3.Add(wavingIt);
    }

    void Spawn0()
    {
        //This is where the info goes to add to the list and such
        if (Waves0.Count < 15)
        {
            wavingIt = Instantiate(wavePrefab, newPosition0, Quaternion.identity);
            newPosition0 = wavingIt.transform.position;
            newPosition0.x += waveSize;
            Waves0.Add(wavingIt);
            waveOrder0 = 0;
        }
    }

    void Spawn1()
    {
        if (Waves1.Count < 15)
        {
            wavingIt = Instantiate(wavePrefab, newPosition1, Quaternion.identity);
            newPosition1 = wavingIt.transform.position;
            newPosition1.x += waveSize;
            Waves1.Add(wavingIt);
            waveOrder1 = 1;
        }
    }

    void Spawn2()
    {
        if (Waves2.Count < 15)
        {
            wavingIt = Instantiate(wavePrefab, newPosition2, Quaternion.identity);
            newPosition2 = wavingIt.transform.position;
            newPosition2.x += waveSize;
            Waves2.Add(wavingIt);
            waveOrder2 = 2;
        }
    }

    void Spawn3()
    {
        if (Waves2.Count < 15)
        {
            wavingIt = Instantiate(wavePrefab, newPosition3, Quaternion.identity);
            newPosition3 = wavingIt.transform.position;
            newPosition3.x += waveSize;
            Waves3.Add(wavingIt);
            waveOrder3 = 3;
        }
    }

    void ResetList()
    {
        if (Waves0.Count != 0 || Waves1.Count != 0 || Waves2.Count != 0)
        {
            Waves0.Clear();
            Waves1.Clear();
            Waves2.Clear();
            Waves3.Clear();
        }
    }
}
