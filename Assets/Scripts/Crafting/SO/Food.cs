using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Perks {Resilient, Agile, Strengthen, Dampening}

[CreateAssetMenu(fileName = "NewMaterial", menuName = "Item/Food")]
public class Food : Item
{
    public Perks[] perks;

    public Food() {
        this.setItemType(ItemType.Food);
    }
}
