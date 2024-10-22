using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class CraftingMenuManager : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject itemArea;
    [SerializeField] GameObject craftingArea;
    [SerializeField] GameObject resultsArea;

    [SerializeField] InventoryManager inventory;
    [SerializeField] List<GameObject> itemObjects = new List<GameObject>();

    [SerializeField] CraftingManager craftingManager;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<InventoryManager>();
        craftingManager = this.gameObject.GetComponent<CraftingManager>();
    }


    //Will populate items into the item inventory panel
    public void PopulateItems() {
        ItemList[] items = inventory.GetAllItems();
        foreach(ItemList item in items) {
            if(item.item.getItemType() == ItemType.Material) {
                GameObject newItem = Instantiate(itemPrefab, itemArea.transform);
                newItem.GetComponent<ItemInfo>().LoadItemInfo(item, this.gameObject);
                itemObjects.Add(newItem);
            }
        }
    }

    //Destroys all items
    public void RemoveAllItems() {
        foreach (GameObject item in itemObjects.ToArray()) {
            itemObjects.Remove(item);
            Destroy(item);
        }
    }

    //Adds an item to either the item inventory panel or the crafting area panel
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
        } else {
            item.gameObject.transform.parent = craftingArea.transform;
            item.GetComponent<ItemInfo>().isUsed = true;
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
            RemoveFromRecipe(itemInfo);
        }
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
        bool itemCreated = craftingManager.checkList();
        if (itemCreated) {
            craftingManager.createItem(inventory);
        } else {
            //WARNING MESSAGE
        }
    }

}
