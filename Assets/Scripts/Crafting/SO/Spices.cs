using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Qualities { Sharp, Smooth, Slimely, Dry, Tough, Soft, Fuzzy };
[CreateAssetMenu(fileName = "NewSpice", menuName = "Item/Spices")]
public class Spices : Item 
{
    public Qualities[] qualities;

    public Flavor[] flavorList = new Flavor[5];

    public Spices() {
        this.setItemType(ItemType.Spice);

        this.flavorList[0].name = "Spicy";
        this.flavorList[1].name = "Sweet";
        this.flavorList[2].name = "Bitter";
        this.flavorList[3].name = "Sour";
        this.flavorList[4].name = "Umami";

        for (int i = 0; i < 5; i++) {
            this.flavorList[i].total = 0;
        }
    }
}
 