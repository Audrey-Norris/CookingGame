using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public Recipe recipe;

    public List<ItemList> inputMats;

    public void Start() {

    }

    public void addToList(Material mat) { 
        
    }

    public void createRecipe() {
        bool goodRecipe = true;
        List<ItemList> mats = recipe.getMaterials();
        foreach(var mat in mats) {
            Debug.Log(mat.mat +" " + mat.amount);
            foreach (var input in inputMats) {
                Debug.Log(input.mat + " " + input.amount);
                if (input.mat == mat.mat & input.amount == mat.amount) {
                    goodRecipe = true;
                    break;
                } else {
                    goodRecipe = false;
                }
                Debug.Log("Ingredient Correct!");
            }
           if (!goodRecipe) {
                break;     
           }
        }

        if(!goodRecipe) {
            Debug.Log("Recipe BAD!");
        } else {
            Debug.Log("Recipe Complete!" + recipe);
        }
    }
}
