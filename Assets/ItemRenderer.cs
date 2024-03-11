using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemRenderer : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] ItemList currentItem;

    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text amountText;

    public void createItem(ItemList item) {
        //icon = sprite;
        currentItem = item;
        nameText.text = currentItem.mat.itemName;
        amountText.text = currentItem.amount.ToString();

    }
}
