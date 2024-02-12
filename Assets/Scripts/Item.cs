using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Armor, Weapon, Food, Material };


public class Item : ScriptableObject 
{
    public string itemName;
    public string description;
    public ItemType type;
    public int value;

}
