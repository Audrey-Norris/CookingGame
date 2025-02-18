using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CraftingMenuManager : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject recipePrefab;
    [SerializeField] GameObject recipeArea;
    [SerializeField] GameObject itemArea;
    [SerializeField] GameObject craftingArea;
    [SerializeField] GameObject resultsArea;
    [SerializeField] GameObject toolTip;

    [SerializeField] InventoryManager inventory;
    [SerializeField] RecipeManager recipes;
    [SerializeField] List<GameObject> itemObjects = new List<GameObject>();
    [SerializeField] List<GameObject> craftingObjects = new List<GameObject>();
    [SerializeField] List<GameObject> recipeObjects = new List<GameObject>();

    [SerializeField] CraftingManager craftingManager;

    private Coroutine tooltipCoroutine;

    [SerializeField] private int currentStage = 0;


    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("SaveManager").GetComponent<InventoryManager>();
        recipes = GameObject.Find("SaveManager").GetComponent<RecipeManager>();
        craftingManager = this.gameObject.GetComponent<CraftingManager>();
    }


    //Will populate items into the item inventory panel
    public void PopulateItems() {
        ItemList[] items = inventory.GetAllItems();
        foreach(ItemList item in items) {
            switch(currentStage) {
                case 0:
                    if (item.item.getItemType() == ItemType.Material) {
                        ItemList itemInfoCopy = new ItemList(item.GetItem(), item.GetTotal());
                        GameObject newItem = Instantiate(itemPrefab, itemArea.transform);
                        newItem.GetComponent<ItemInfo>().LoadItemInfo(itemInfoCopy, this.gameObject);
                        itemObjects.Add(newItem);
                    }
                    break;
                case 1:
                    if (item.item.getItemType() == ItemType.Spice) {
                        ItemList itemInfoCopy = new ItemList(item.GetItem(), item.GetTotal());
                        GameObject newItem = Instantiate(itemPrefab, itemArea.transform);
                        newItem.GetComponent<ItemInfo>().LoadItemInfo(itemInfoCopy, this.gameObject);
                        itemObjects.Add(newItem);
                    }
                    break;
                default:
                    break;
            }

        }
    }

    //Destroys all items
    public void RemoveAllItems() {
        foreach (GameObject item in itemObjects.ToArray()) {
            itemObjects.Remove(item);
            Destroy(item);
        }
        foreach (GameObject item in craftingObjects.ToArray()) {
            craftingObjects.Remove(item);
            Destroy(item);
        }
    }


    //Adds an item to crafting area panel
    public void addItemCrafting(GameObject item) {
        ItemList itemInfo = item.GetComponent<ItemInfo>().itemInfo;
        ItemList newItemInfo = new ItemList(itemInfo.item, itemInfo.total);
        if (itemInfo.GetTotal() > 1) {
            GameObject newItem = Instantiate(item);
            itemInfo.SetTotal((itemInfo.GetTotal() - 1));
            item.GetComponent<ItemInfo>().UpdateItemInfo(itemInfo);
            newItemInfo.SetTotal(1);
            newItem.GetComponent<ItemInfo>().UpdateItemInfo(newItemInfo);
            newItem.transform.parent = craftingArea.transform; //SHOULD ADD ADDING FUNCTION
            newItem.GetComponent<ItemInfo>().isUsed = true;
            AddToRecipe(newItemInfo);
            craftingObjects.Add(newItem);
        } else {
            item.gameObject.transform.parent = craftingArea.transform;
            item.GetComponent<ItemInfo>().isUsed = true;
            itemObjects.Remove(item);
            craftingObjects.Add(item);
            AddToRecipe(itemInfo);
        }

    }

    public void addItemInven(GameObject item) {
        ItemList itemInfo = item.GetComponent<ItemInfo>().itemInfo;
        ItemList newItemInfo = new ItemList(itemInfo.item, itemInfo.total);
        if (itemInfo.GetTotal() > 1) {
            GameObject newItem = Instantiate(item);
            itemInfo.SetTotal((itemInfo.GetTotal() - 1));
            item.GetComponent<ItemInfo>().UpdateItemInfo(itemInfo);

            newItemInfo.SetTotal(1);
            newItem.GetComponent<ItemInfo>().UpdateItemInfo(newItemInfo);
            newItem.GetComponent<ItemInfo>().isUsed = false;
            newItem.transform.parent = itemArea.transform; //SHOULD ADD ADDING FUNCTION
            RemoveFromRecipe(newItemInfo);

        } else {
            item.gameObject.transform.parent = itemArea.transform;
            item.GetComponent<ItemInfo>().isUsed = false;
            itemObjects.Add(item);
            RemoveFromRecipe(itemInfo);
        }
        craftingObjects.Remove(item);
    }

    public void TurnOnToolTip(GameObject item) {
        toolTip.SetActive(true);
        toolTip.GetComponent<ToolTipInfo>().LoadInfo(item);
    }

    public void TurnOffToolTip(GameObject item) {
        toolTip.SetActive(false);
    }

    //Removes an item from either the item inventory panel or the crafting area panel
    private void removeItem() {

    }

    //Updates the info in the info section based on whats in other sections
    private void updateInfo() {

    }

    private void AddToRecipe(ItemList item) {
        craftingManager.addMaterial(item);
    }

    private void RemoveFromRecipe(ItemList item) {
        craftingManager.reduceMaterial(item.GetItem());
    }

    public void craftItem() {
        craftingManager.createItem(inventory);
        RemoveAllItems();
        PopulateItems();
    }


    public void setCurrentRecipe(Recipe recipe) {
        //ADD VISUAL FEEDBACK
        craftingManager.setRecipe(recipe);
    }

    public void PopulateRecipes() {
        Recipe[] recipeList = recipes.GetAllRecipes();
        foreach (Recipe recipe in recipeList) {
            GameObject newItem = Instantiate(recipePrefab, recipeArea.transform);
            newItem.GetComponent<RecipeInfo>().LoadItemInfo(recipe, this.gameObject);
            recipeObjects.Add(newItem);
        }
    }

    //Destroys all items
    public void RemoveAllRecipes() {
        foreach (GameObject recipe in recipeObjects.ToArray()) {
            recipeObjects.Remove(recipe);
            Destroy(recipe);
        }
    }
}
