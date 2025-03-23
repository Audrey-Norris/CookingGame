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


    [SerializeField] private int spicy = 0, sweet = 0, bitter = 0, sour = 0, savory = 0;

    public void PopulateSpices() {
        inventory = GameObject.Find("SaveManager").GetComponent<InventoryManager>();
        ItemList[] spices = inventory.GetAllItems();

        foreach (ItemList spice in spices) {
            Debug.Log(spice.item.name);
            Debug.Log(spice.total);
            if(spice.item.getItemType() == ItemType.Spice) {
                CreateSpiceObject(spice, spiceArea, spiceObjects);
            }
        }
    }

    public void CreateSpiceObject(ItemList info, GameObject parent , List<GameObject> location) {
        GameObject newSpice = Instantiate(itemPrefab, parent.transform);
        newSpice.GetComponent<ItemInfo>().LoadItemInfo(info, this.gameObject);
        location.Add(newSpice);
    }

    public void AddSpice(GameObject spice) {
        ItemList itemInfo = spice.GetComponent<ItemInfo>().itemInfo;
        GameObject location;
        List<GameObject> listLocation;
        //Determines the location the item is going to
        if (spice.transform.parent.name == spiceArea.name) {
            location = activeSpiceArea;
            listLocation = activeSpiceObjects;

        } else {
            location = spiceArea;
            listLocation = spiceObjects;
        }

        if (itemInfo.total > 1) { //If there is greater than 1 spice objects create a new object
            Debug.Log("Running!");
            ItemList newItem = new ItemList(itemInfo.item, 1);
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

    //Takes the entire list of spices currently active and calculates the spice value of the dish
    public void UpdateValues() {
        spicy = 0;
        sweet = 0;
        bitter = 0;
        savory = 0;
        sour = 0;
        if(activeSpiceObjects.Count != 0) {
            foreach (GameObject x in activeSpiceObjects) {
                Spices spice = (Spices)x.GetComponent<ItemInfo>().itemInfo.item;
                foreach (Flavor flavor in spice.flavorList) {
                    switch (flavor.name) {
                        case "Spicy": //Spicy reduces sweetness
                            spicy += flavor.total;
                            sweet -= Mathf.FloorToInt(flavor.total / 3);
                            break;
                        case "Sweet": //Sweet enchances umami and reduces spicy and bitter
                            sweet += flavor.total;
                            savory += Mathf.FloorToInt(flavor.total / 3);
                            spicy -= Mathf.FloorToInt(flavor.total / 3);
                            bitter -= Mathf.FloorToInt(flavor.total / 3);
                            break;
                        case "Bitter": //Bitter reduces savory and sweet
                            bitter += flavor.total;
                            savory -= Mathf.FloorToInt(flavor.total / 3);
                            sweet -= Mathf.FloorToInt(flavor.total / 3);
                            break;
                        case "Sour": //Sour reduces bitter and spice and sweet
                            sour += flavor.total;
                            spicy -= Mathf.FloorToInt(flavor.total / 3);
                            bitter -= Mathf.FloorToInt(flavor.total / 3);
                            sweet -= Mathf.FloorToInt(flavor.total / 3);
                            break;
                        case "Umami": //Savory enhances sweet reduces bitter
                            savory += flavor.total;
                            sweet += Mathf.FloorToInt(flavor.total / 3);
                            bitter -= Mathf.FloorToInt(flavor.total / 3);
                            break;
                    }
                }
            }
        }
        
        //Updates slider values
        sliders.AddFlavor("Spicy", spicy);
        sliders.AddFlavor("Sweet", sweet);
        sliders.AddFlavor("Umami", savory);
        sliders.AddFlavor("Sour", sour);
        sliders.AddFlavor("Bitter", bitter);
    }

    public void CraftItems() {

    }

    public void SetRecipe(Recipe recipe) {
        currentRecipe = recipe;
    }

}
