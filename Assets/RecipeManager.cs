using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    [SerializeField] public List<Recipe> knownRecipes = new List<Recipe>();

    public Recipe[] GetAllRecipes() {
        return knownRecipes.ToArray();
    }

    public Recipe GetRecipe(string name) {
        if (knownRecipes.Find(x => x.name == name) != null) {
            return knownRecipes[(knownRecipes.FindIndex(x => x.name == name))];
        }
        return null;
    }
}
