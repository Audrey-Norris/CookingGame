using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiceManager : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private InventoryManager inventory;

    [SerializeField] private List<GameObject> spiceObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> activeSpiceObjects = new List<GameObject>();
    
    [SerializeField] private GameObject spiceArea;
    [SerializeField] private GameObject activeSpiceArea;

    [SerializeField] private Recipe currentRecipe;

    [SerializeField] private SliderManager sliders;

    public void PopulateSpices() {
        inventory = GameObject.Find("SaveManager").GetComponent<InventoryManager>();
        ItemList[] spices = inventory.GetAllItems();

        foreach (ItemList spice in spices) {
            if(spice.item.getItemType() == ItemType.Spice) {
                CreateSpiceObject(spice, spiceArea, spiceObjects);
            }
        }
    }

    public void CreateSpiceObject(ItemList info, GameObject parent , List<GameObject> location) {
        GameObject newSpice = Instantiate(itemPrefab, parent.transform);
        itemPrefab.GetComponent<ItemInfo>().LoadItemInfo(info, this.gameObject);
        location.Add(newSpice);
    }

    public void AddSpice(GameObject spice) {
        ItemList itemInfo = spice.GetComponent<ItemInfo>().itemInfo;
        GameObject location;
        List<GameObject> listLocation;
        if (spice.transform.parent == spiceArea) {
            location = activeSpiceArea;
            listLocation = activeSpiceObjects;
        } else {
            location = spiceArea;
            listLocation = spiceObjects;
        }

        if (itemInfo.total > 1) { //If there is greater than 1 spice objects create a new object
            ItemList newItem = new ItemList(itemInfo.item, itemInfo.total);
            CreateSpiceObject(newItem, location, listLocation);
            itemInfo.total--;
            spice.GetComponent<ItemInfo>().UpdateItemInfo(itemInfo);
        } else { //If this is the last object change it's parent
            spice.transform.SetParent(location.transform);
            if (listLocation == activeSpiceObjects) {
                spiceObjects.Remove(spice);
                activeSpiceObjects.Add(spice);
            } else {
                activeSpiceObjects.Remove(spice);
                spiceObjects.Add(spice);
            }
        }
        //Updates the current slider values
        UpdateValues();
    }

    public void RemoveSpice() { //Might Not Need

    }

    public void UpdateValues() {

    }

    public void CraftItems() {

    }

    public void SetRecipe(Recipe recipe) {
        currentRecipe = recipe;
    }

}
