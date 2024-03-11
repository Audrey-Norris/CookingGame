using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CraftingManager : MonoBehaviour
{
    [SerializeField] Recipe recipe;
    [SerializeField] List<ItemList> inputMats = new List<ItemList>();

    [SerializeField] int inputSize = 0;

    [SerializeField] ItemList createdItem;


    [SerializeField] TMP_Text recipeName;
    [SerializeField] TMP_Text items;

    //FOR DEMOING PURPOSES
    public void Start()
    {
        inputSize = inputMats.Count;
        foreach(ItemList mats in inputMats)
        {
            items.text += mats.mat.itemName + " ";
        }
    }

    //FOR DEMOING PURPOSES
    public void Update()
    {
        ItemList result = recipe.getResult();
        recipeName.text = result.mat.itemName;
        
        if(inputSize != inputMats.Count)
        {
            items.text = "";
            foreach (ItemList mats in inputMats)
            {
                items.text += mats.mat.itemName + " ";
            }
            inputSize = inputMats.Count;
        }

    }


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
    public bool checkRecipe() {
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
        if (!goodRecipe)
        {
            Debug.Log("Recipe BAD!");
        }
        else
        {
            Debug.Log("Recipe Complete! " + recipe);
        }
        return goodRecipe;
    }

    public void CreateRecipe()
    {
        if(checkRecipe())
        {
            createdItem = recipe.getResult();
            Debug.Log("Item Created! " + createdItem.mat.itemName);
        } else
        {
            Debug.Log("Recipe cannot be created!");
        }
    }


}
