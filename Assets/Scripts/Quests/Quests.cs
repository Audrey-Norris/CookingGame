using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest")]
public class Quests : ScriptableObject
{
    public string questName;

    [TextArea(15, 20)]
    public string questDescription;

    public Food itemNeeded;

    public Perks[] foodPerks;

    public Flavor[] flavorList = new Flavor[5];

    public bool isCompleted = false;

    public bool isActive = false;

    public Factions faction;

    public Quests() {

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
