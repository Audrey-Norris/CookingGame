using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour
{

    [SerializeField] InventoryManager inventory;
    [SerializeField] List<GameObject> itemObjects = new List<GameObject>();
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject itemArea;

    [SerializeField] GameObject toolTip;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("SaveManager").GetComponent<InventoryManager>();
    }

    public void PopulateItems() {
        ItemList[] items = inventory.GetAllItems();
        foreach (ItemList item in items) {
            if (item.item.getItemType() == ItemType.Material) {
                ItemList itemInfoCopy = new ItemList(item.GetItem(), item.GetTotal());
                GameObject newItem = Instantiate(itemPrefab, itemArea.transform);
                newItem.GetComponent<ItemInfo>().LoadItemInfo(itemInfoCopy, this.gameObject);
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

    public void TurnOnToolTip(GameObject item) {
        toolTip.SetActive(true);
        toolTip.GetComponent<ToolTipInfo>().LoadInfo(item);
    }

    public void TurnOffToolTip(GameObject item) {
        toolTip.SetActive(false);
    }
}