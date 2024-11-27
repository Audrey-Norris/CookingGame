using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<ItemList> totalItems = new List<ItemList>();

    public ItemList[] GetAllItems() {
        return totalItems.ToArray();
    }

    public void AddItem(ItemList newItem) {
        totalItems.Add(newItem);
    }

    public void AddItem(Item newItem) {
        
    }

    public void ReduceItem(Item removeItem) {
        if (totalItems.Exists(obj => obj.item == removeItem)) {
            int index = totalItems.FindIndex(obj => obj.item == removeItem);
            ItemList item = totalItems[index];
            item.total -= 1;
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
}
