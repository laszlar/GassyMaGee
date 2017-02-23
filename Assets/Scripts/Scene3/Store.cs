using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour {

    private readonly Inventory _inv = new Inventory();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _inv.IsFull = _inv.IsInventoryFull();   
	}

    public void PaintButton()
    {
        if (!!_inv.IsFull)
            return;

        if (!_inv.IsFull)
        {
            Debug.Log("Paint added to inventory");
            _inv.InventoryList.Add(Inventory.Items.Paint);
        }
    }

    public void ChuteButton()
    {
        if (!!_inv.IsFull)
            return;

        if (!_inv.IsFull)
        {
            Debug.Log("Parachute added to inventory");
            _inv.InventoryList.Add(Inventory.Items.Chute);
        }
    }

}
