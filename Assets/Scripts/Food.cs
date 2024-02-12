using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Items/Food")]
public class Food : Item {
    public string foodEffect;
    public int healing;

    public void Awake() {
        this.type = ItemType.Food;
    }

    //ALL FOODS GET AN EFFECT OF SOME VARIETY WITHIN THEIR CODE
    public void activateFood() {
        
    }
}
