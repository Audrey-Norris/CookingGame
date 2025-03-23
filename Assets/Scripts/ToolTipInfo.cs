using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolTipInfo : MonoBehaviour
{

    [SerializeField] TMP_Text itemTitle;
    [SerializeField] TMP_Text itemDescription;
    [SerializeField] TMP_Text itemAmount;

    [SerializeField] public bool isActive = false;

    public void LoadInfo(GameObject itemObject) {
        ItemList item = itemObject.GetComponent<ItemInfo>().itemInfo;
        itemTitle.text = item.item.Name;
        itemDescription.text = item.item.Description;
        itemAmount.text = item.GetTotal().ToString();
        this.transform.position = new Vector3(itemObject.transform.position.x+300, itemObject.transform.position.y-100, itemObject.transform.position.z);
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
