using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Material, Equipment, Food, Spice };
public enum Rarity { Common, Uncommon, Rare, Expert };

public class Item : ScriptableObject
{
    public string Name;
    [TextArea(5, 10)] 
    public string Description;
    public int Cost;
    public Rarity Rarity;

    private ItemType Type;

    public ItemType getItemType() {
        return Type;
    }
    public void setItemType(ItemType type) {
        Type = type;
    }
}
