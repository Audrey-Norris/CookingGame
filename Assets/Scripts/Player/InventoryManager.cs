using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class InventoryManager : MonoBehaviour, IDataPersistance 
{
    [SerializeField] private List<Item> allItems = new List<Item>();

    [SerializeField] private List<ItemList> totalItems = new List<ItemList>();

    public ItemList[] GetAllItems() {
        return totalItems.ToArray();
    }

    public void AddItem(ItemList newItem) {
        totalItems.Add(newItem);
    }

    public void AddItem(Item newItem) {
        totalItems.Add(new ItemList(newItem, 1));
    }

    public void AddItem(Item newItem, int i) {
        totalItems.Add(new ItemList(newItem, i));
    }

    public void ReduceItem(Item removeItem) {
        if (totalItems.Exists(obj => obj.item == removeItem)) {
            int index = totalItems.FindIndex(obj => obj.item == removeItem);
            ItemList item = totalItems[index];
            item.total --;
            if (item.total <= 0) {
                RemoveItem(removeItem);
            }
        }
    }

    public void RemoveItem(Item removeItem) {
        if (totalItems.Exists(obj => obj.item == removeItem)) {
            int index = totalItems.FindIndex(obj => obj.item == removeItem);
            totalItems.RemoveAt(index);
        }
    }

    public bool DoesItemExist(ItemList item) {
        return totalItems.Exists(obj => obj.item == item.item);
    }

    public void FaciliateUnlocks(Unlock unlock) {
        AddItem(allItems.Find(x => x.Name == unlock.unlockName));
    }

    public void LoadData(GameData data) {
    }

    public void SaveData(ref GameData data) {

    }

    public void NewGame(ref GameData data) {
        totalItems.Clear();
        string item = data.inventory[0].itemName;
        AddItem(allItems.Find(x => x.Name == item), 2);
    }
}
