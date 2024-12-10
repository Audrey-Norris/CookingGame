using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest")]
public class Quests : ScriptableObject
{
    public string questName;

    [TextArea(15, 20)]
    public string questDescription;

    public List<ItemList> itemsNeeded = new List<ItemList>();

    public Perks[] foodPerks;

    public bool isCompleted = false;

    public bool isActive = false;

    public Buildings buildingReward;
}
