using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [SerializeField] Recipe recipe;
    [SerializeField] List<ItemList> inputMats = new List<ItemList>();


    public void selectRecipe(Recipe newRecipe) {
        recipe = newRecipe;
    }

    //Adds a singular mat to the list
    public void addToList(Item inputMat) {
        if(inputMats.Exists(obj => obj.mat == inputMat)) {
            int index = inputMats.FindIndex(obj => obj.mat == inputMat);
            ItemList itemAdd = inputMats[index];
            itemAdd.amount += 1;
            inputMats[index] = itemAdd;
        } else {
            ItemList itemAdd = new ItemList();
            itemAdd.mat = inputMat;
            itemAdd.amount = 1;
            inputMats.Add(itemAdd);
        }
    }

    public void addToList(ItemList inputMat) {
        if (inputMats.Exists(obj => obj.mat == inputMat.mat)) {
            int index = inputMats.FindIndex(obj => obj.mat == inputMat.mat);
            ItemList itemAdd = inputMats[index];
            itemAdd.amount += inputMat.amount;
            inputMats[index] = itemAdd;
        } else {
            inputMats.Add(inputMat);
        }
    }


    //Takes an array of mats and adds them to the list.
    public void addToList(Item[] inputMats) {
        for (int i = 0; i < inputMats.Length; i++) {
            addToList(inputMats[i]);
        }
    }


    //Takes the input mats and checks if they match the recipe mats list.
    public ItemList checkRecipe() {
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
            }
           if (!goodRecipe) {
                break;  
                 
           }
        }

        return recipe.getResult();
    }


}
