using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RecipeType { Common, Uncommon, Rare, Expert };

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Recipe")]
public class Recipe : ScriptableObject 
{
    public string Name;
    public RecipeType Type;

    public int Cost;

    public ItemList[] materials;

    public ItemList[] craftedItems;

    public int timeToCraft;

}
