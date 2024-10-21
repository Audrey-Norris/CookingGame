using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] List<ItemList> totalItems = new List<ItemList>();

    public ItemList[] GetAllItems() {
        return totalItems.ToArray();
    }

    public void AddItem(ItemList newItem) {
        totalItems.Add(newItem);
    }

    public void AddItem(Item newItem) {
        
    }

    public void RemoveItem(Item removeItem) {
        
    }
}
