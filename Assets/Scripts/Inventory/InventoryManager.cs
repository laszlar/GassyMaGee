using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    private bool inventoryFull;

    [SerializeField]
    private GameObject paint;
    [SerializeField]
    private GameObject parachute;
    [SerializeField]
    private PlayerMovement playerScript;
    [SerializeField]


    List <GameObject> inventoryItems = new List<GameObject>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    
    // Use this for initialization
    void Start ()
    {
        paint = GameObject.Find("PaintImage");
        parachute = GameObject.Find("ParachuteImage");
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (inventoryItems.Count == 3)
        {
            inventoryFull = true;
        }


        if (!inventoryFull)
        {
            inventoryItems.Add(gameObject);
        }
        else
        {
            return;
        }

        
	}

    private void ParachuteButton()
    {
        if 
    }

    private void PaintButton()
    {

    }
}
