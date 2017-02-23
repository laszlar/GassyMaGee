using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryLoader : MonoBehaviour {

    private readonly Inventory _inv = new Inventory();
    [SerializeField]
    private Sprite _paint;
    [SerializeField]
    private Sprite _chute;

	// Use this for initialization
	void Start () {
        _inv.LoadInventory();
	}
	
	// Update is called once per frame
	void Update () {
        DisplaySprites();
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

    private void DisplaySprites()
    {
        for (var i = 0; i < _inv.InventoryList.Count; i++)
        {
            if (_inv.InventoryList[i] == Inventory.Items.Chute)
            {
                // dislpay chute in slot [i]
            }
            else if ( _inv.InventoryList[i] == Inventory.Items.Paint)
            {
                // display paint in slot [i]
            }
        }

        if(_inv.InventoryList.Count < 3)
        {
            // remove item slot sprite 3
        }
        if (_inv.InventoryList.Count < 2)
        {
            // remove item slot sprite 2
        }
        if (_inv.InventoryList.Count < 1)
        {
            // remove item slot sprite 1
        }
    }
}
