using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Perks {Resilient, Agile, Strengthen, Dampening}

[CreateAssetMenu(fileName = "NewMaterial", menuName = "Item/Food")]
public class Food : Item
{
    public Perks[] perks;

    public Flavor[] flavorList = new Flavor[5];

    public Food() {
        this.setItemType(ItemType.Food);

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
