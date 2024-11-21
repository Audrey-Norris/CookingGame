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
    public int totalPlaytime;
    public int[] locationPlaytime;
    public string questChosen;


    //Inventory SO Names and totals
    public List<InventoryItem> inventory;

    public GameData()
    {
        
    }

}