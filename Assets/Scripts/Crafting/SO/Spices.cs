using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Qualities { Sharp, Smooth, Slimely, Dry, Tough, Soft, Fuzzy };
[CreateAssetMenu(fileName = "NewSpice", menuName = "Item/Spices")]
public class Spices : Item 
{
    public Qualities[] qualities;

    public Spices() {
        this.setItemType(ItemType.Spice);
    }
}
 