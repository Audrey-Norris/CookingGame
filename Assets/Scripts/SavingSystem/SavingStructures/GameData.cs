using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

public class QuestItem {
    public string questName;
    public int isCompleted;

    public QuestItem(string name, int total) {
        isCompleted = total;
        questName = name;
    }
}

[System.Serializable]
public class GameData
{
    public float totalPlaytime = 0f; // Nothing Yet
    public int totalDays = 0; //Nothing Yet

    public bool isTutorial = false; // Quest Manager - Probably should be on a stats page with the other two above :P

    //NEED RENOWN NO UNLOCKS BECAUSE RENOWN DENOTES UNLOCKS :)
    public List<Renown> renown; // Renown Manager
    public List<Quests> completedQuests; // Quest Manager


    //MIGHT NOT NEED THESE YET
    public List<Recipe> recipes; // Recipe Manager

    //Inventory SO Names and totals
    public List<InventoryItem> inventory; // Inventory Manager

    //Starts a new game with items that would be needed at the start of a new game.
    public GameData(InventoryItem[] spices, Quests quest, Recipe recipe)
    {
        totalPlaytime = 0f;
        totalDays = 0;

        isTutorial = false;

        recipes = new List<Recipe>();
        recipes.Add(recipe);

        inventory = new List<InventoryItem>();
        foreach (InventoryItem sp in spices) {
            inventory.Add(sp);
        }

        completedQuests = new List<Quests> ();
        completedQuests.Add(quest);

    }

}