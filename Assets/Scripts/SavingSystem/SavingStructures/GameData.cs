using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public int amount;
    public string itemName;

    public InventoryItem(string name, int total)
    {
        amount = total;
        itemName = name;
    }
}


[System.Serializable]
public class GameData
{
    public float totalPlaytime;
    public int totalDays = 0;

    //NEED RENOWN
    public List<Renown> renown;

    //NEED UNLOCKS

    //Inventory SO Names and totals
    public List<InventoryItem> inventory;

    public GameData()
    {
        
    }

}