using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [SerializeField] private Recipe currentRecipe;
    [SerializeField] private List<ItemList> materials = new List<ItemList>();

    public void clearRecipe() {
        currentRecipe = null;
    }

    public void setRecipe(Recipe recipe) {
        currentRecipe = recipe;
    }

    public void clearMaterials() {
        materials = new List<ItemList>();
    }

    public void removeMaterial(Material material) {
        if (materials.Exists(obj => obj.item == material)) {
            int index = materials.FindIndex(obj => obj.item == material);
            materials.RemoveAt(index);
        }
    }

    public void reduceMaterial(Material material) {
        if(materials.Exists(obj => obj.item == material)) {
            int index = materials.FindIndex(obj => obj.item == material);
            ItemList item = materials[index];
            item.total -= 1;
            if(item.total <= 0) {
                removeMaterial(material);
            }
        }
    }

    public void addMaterials(Material[] material) { 
        foreach(Material mat in material) {
            addMaterial(mat);
        }
    }

    public void addMaterial(Material material) {
        if (materials.Exists(obj => obj.item == material)) {
            int index = materials.FindIndex(obj => obj.item == material);
            ItemList item = materials[index];
            item.total += 1;
            materials[index] = item;
        } else {
            ItemList itemAdd = new ItemList();
            itemAdd.total = 1;
            itemAdd.item = material;
            materials.Add(itemAdd);
        }
    }

    //NOT MAKING RIGHT NOW MIGHT IN THE FUTURE
    public void addMaterial(ItemList material) {

    }

    public bool checkList() {
        bool matCheck = false;
        //Loops through each item that has been added to the list
        foreach(ItemList addedItem in materials) {
            //Loops through each item that is in the recipe
            foreach(ItemList recipeItem in currentRecipe.materials) {
                //If an item added to the list matches the recipe then mat check is true and we break out of the loop else mat check is false.
                if(recipeItem.item.name == addedItem.item.name && recipeItem.total == addedItem.total) {
                    matCheck = true;
                    break;
                } else {
                    matCheck = false;
                }
            }
            //If at any time matCheck is still false after a loop the added item is incorrect and the function returns false.
            if (!matCheck) {
                return false;
            }
        }
        //If they get through all the items and have no issues then return true.
        return true;
    }

    public void createItem() {
        if(checkList()) {
            Debug.Log("Correct Items!");
        }
    }
}
