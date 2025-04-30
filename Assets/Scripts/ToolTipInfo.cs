using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolTipInfo : MonoBehaviour
{

    [SerializeField] TMP_Text itemTitle;
    [SerializeField] TMP_Text itemDescription;
    [SerializeField] TMP_Text itemAmount;

    [SerializeField] SliderManager flavorSliders;

    [SerializeField] public bool isActive = false;

    public void LoadInfo(GameObject itemObject) {
        ItemList item = itemObject.GetComponent<ItemInfo>().itemInfo;
        itemTitle.text = item.item.Name;
        itemDescription.text = item.item.Description;

        if(itemObject.GetComponent<ItemInfo>().GetMenu().GetComponent<InventoryCanvas>()) {
            if(item.item.getItemType() == ItemType.Food) {
                LoadFlavor(itemObject);
            }
        } else {
            itemAmount.text = item.GetTotal().ToString();
            int screenWidth = Screen.width;
            int screenHeight = Screen.height;
            this.transform.position = new Vector3(itemObject.transform.position.x + (screenWidth*0.3f), itemObject.transform.position.y - (screenHeight * 0.15f), itemObject.transform.position.z);
        }
    }

    public void LoadFlavor(GameObject itemObject) {
        Food food = (Food)itemObject.GetComponent<ItemInfo>().itemInfo.item;
        for (int i = 0; i < food.flavorList.Length; i++) {
            flavorSliders.AddFlavor(food.flavorList[i].name, food.flavorList[i].total);
        }
    }

    /*
    public void LoadRecipe(GameObject itemObject) {
        Recipe recipe = itemObject.GetComponent<RecipeInfo>().recipe;
        itemTitle.text = recipe.Name;
        itemDescription.text = recipe.;
        itemAmount.text = ;
        this.transform.position = new Vector3(itemObject.transform.position.x + 300, itemObject.transform.position.y - 100, itemObject.transform.position.z);
    } */
}
