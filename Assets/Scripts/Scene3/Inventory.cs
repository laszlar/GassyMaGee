using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory> {

    [SerializeField]  private GameObject paint;
    [SerializeField] private GameObject parachute;
    [SerializeField] private PlayerMovement playerScript;

    List<GameObject> InventoryList = new List<GameObject>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
