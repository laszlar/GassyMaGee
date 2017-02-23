using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryLoader : MonoBehaviour {

    private readonly Inventory _inv = new Inventory();

	// Use this for initialization
	void Start () {
        _inv.LoadInventory();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Btn1()
    {
        if (_inv.InventoryList.Count < 1)
            return;

        if (_inv.InventoryList.Count >= 1)
        {
            Debug.Log("Pressed the mother fucking button");
            _inv.InventoryList.RemoveAt(0);
        }
    }

    public void Btn2()
    {
        if (_inv.InventoryList.Count <= 2)
            return;

        if (_inv.InventoryList.Count >= 3)
        {
            Debug.Log("Pressed the mother fucking button");
            _inv.InventoryList.RemoveAt(1);
        }
    }

    public void Btn3()
    {
        if (_inv.InventoryList.Count < 3)
            return;

        if (_inv.InventoryList.Count == 3)
        {
            Debug.Log("Pressed the mother fucking button");
            _inv.InventoryList.RemoveAt(2);
        }
    }
}
