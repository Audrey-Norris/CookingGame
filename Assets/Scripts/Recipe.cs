using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemList {
    public Item mat;
    public int amount;
}

[CreateAssetMenu(fileName = "New Recipe", menuName = "Items/Recipe")]
public class Recipe : ScriptableObject
{
    public List<ItemList> Material;
    public List<ItemList> Result;

    public List<ItemList> getMaterials() {
        return Material;
    }

    public List<ItemList> getResult() {
        return Result;
    }
}

