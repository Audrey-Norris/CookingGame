using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        if (itemInfo.GetTotal() > 1) {
            GameObject newItem = Instantiate(item);

            itemInfo.SetTotal(itemInfo.GetTotal() - 1);
            item.GetComponent<ItemInfo>().UpdateItemInfo(itemInfo);

            itemInfo.SetTotal(1);
            newItem.GetComponent<ItemInfo>().UpdateItemInfo(itemInfo);
            newItem.transform.parent = craftingArea.transform; //SHOULD ADD ADDING FUNCTION
            

        } else {
            item.gameObject.transform.parent = craftingArea.transform;
        }
    }

    public void addItemInven(GameObject item) {
        ItemList itemInfo = item.GetComponent<ItemInfo>().itemInfo;
        if (itemInfo.GetTotal() > 1) {
            GameObject newItem = Instantiate(item);
            itemInfo.SetTotal(itemInfo.GetTotal() - 1);
            item.GetComponent<ItemInfo>().UpdateItemInfo(itemInfo);

            itemInfo = newItem.GetComponent<ItemInfo>().itemInfo;
            itemInfo.SetTotal(1);
            newItem.GetComponent<ItemInfo>().UpdateItemInfo(itemInfo);

            newItem.transform.parent = itemArea.transform; //SHOULD ADD ADDING FUNCTION

        } else {
            item.gameObject.transform.parent = itemArea.transform;
        }
    }

    //Removes an item from either the item inventory panel or the crafting area panel
    private void removeItem() {

    }

    //Updates the info in the info section based on whats in other sections
    private void updateInfo() {

    }


}
