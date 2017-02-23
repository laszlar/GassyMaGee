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

        if(ScoreTracker.score < 10)
        {
            Debug.Log("You don't have enough points to buy this item.");
            return;
        }

        if (!_inv.IsFull && ScoreTracker.score >= 10)
        {
            Debug.Log("Paint added to inventory");
            _inv.InventoryList.Add(Inventory.Items.Paint);
        }
    }

    public void ChuteButton()
    {
        if (!!_inv.IsFull)
            return;

        if (ScoreTracker.score < 5)
        {
            Debug.Log("You don't have enough points to buy this item.");
            return;
        }

        if (!_inv.IsFull && ScoreTracker.score >= 5)
        {
            Debug.Log("Parachute added to inventory");
            _inv.InventoryList.Add(Inventory.Items.Chute);
        }
    }

}
