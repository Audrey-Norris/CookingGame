using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenuManager : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject itemArea;
    [SerializeField] GameObject craftingArea;
    [SerializeField] GameObject resultsArea;

    [SerializeField] InventoryManager inventory;
    [SerializeField] List<GameObject> itemObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<InventoryManager>();
    }

    //Will populate items into the item inventory panel
    public void PopulateItems() {
        ItemList[] items = inventory.GetAllItems();
        foreach(ItemList item in items) {
            if(item.item.getItemType() == ItemType.Material) {
                GameObject newItem = Instantiate(itemPrefab, itemArea.transform);
                newItem.GetComponent<ItemInfo>().LoadItemInfo(item);
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
    private void addItem() {

    }

    //Removes an item from either the item inventory panel or the crafting area panel
    private void removeItem() {

    }

    //Updates the info in the info section based on whats in other sections
    private void updateInfo() {

    }
}
