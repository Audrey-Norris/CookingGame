using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public Recipe currentRecipe;
    public List<Material> materials = new List<Material>();

    public void setRecipe(Recipe recipe) {
        currentRecipe = recipe;
    }

    public void addMaterials(Material[] materials) { 
        
    }

    public void addMaterial(Material material) {
        
    }

    public void addMaterial(ItemList material) {

    }

    public bool checkList() {
        return false;
    }

    public void createItem() {
        if(checkList()) {
            Debug.Log("Correct Items!");
        }
    }
}
