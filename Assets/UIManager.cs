using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using static UnityEditor.Progress;


public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject inventorySection;
    [SerializeField] GameObject craftingSection;
    [SerializeField] GameObject recipeSection;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] InventoryStorage inventory;

    [SerializeField] TMP_Text recipeName;

    [SerializeField] Recipe currentRecipe;

    [SerializeField] ItemList currentItem;

    [SerializeField] CraftingManager craftingManager;

    [SerializeField] ItemList createdItem;

    public void Start() {
        recipeName.text = currentRecipe.Result.mat.itemName;
        foreach(ItemList item in inventory.itemList) {
            addItem(item);
        }
    }

    public void Update() {
        if (createdItem.amount != 0) {
            addCreatedItem(createdItem);
            createdItem.amount = 0;
        }
    }

    public void addItem(ItemList item) {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.parent = inventorySection.transform;
        newSlot.GetComponent<ItemRenderer>().createItem(item);
    }

    public void addCraftingItem() {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.parent = craftingSection.transform;
        craftingManager.addToList(currentItem);
        newSlot.GetComponent<ItemRenderer>().createItem(currentItem);
    }

    public void addCreatedItem(ItemList item) {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.parent = recipeSection.transform;
        newSlot.GetComponent<ItemRenderer>().createItem(item);
    }

}
