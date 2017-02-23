using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    public List<Items> InventoryList = new List<Items>();
    public bool IsFull;

    public enum Items
    {
        Paint,
        Chute
    }

    public bool IsInventoryFull()
    {
        if (InventoryList.Count >= 3)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void SaveInventory()
    {
        if(PlayerPrefs.HasKey("Inv0") || PlayerPrefs.HasKey("Inv1") || PlayerPrefs.HasKey("Inv2"))
        {
            DeleteAllInvKeys();
        }

        for (var i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt("Inv" + i, (int)(InventoryList[i]));
        }

        PlayerPrefs.Save();
    }

    public void LoadInventory()
    {
        if(PlayerPrefs.HasKey("Inv0"))
        {
            InventoryList.Add((Items)PlayerPrefs.GetInt("Inv0"));
        }
        if (PlayerPrefs.HasKey("Inv1"))
        {
            InventoryList.Add((Items)PlayerPrefs.GetInt("Inv1"));
        }
        if (PlayerPrefs.HasKey("Inv2"))
        {
            InventoryList.Add((Items)PlayerPrefs.GetInt("Inv2"));
        }
    }

    public void DeleteAllInvKeys()
    {
        PlayerPrefs.DeleteKey("Inv0");
        PlayerPrefs.DeleteKey("Inv1");
        PlayerPrefs.DeleteKey("Inv2");
    }
}
