using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] Sprite sprite;
    [SerializeField] int total;

    [SerializeField] GameObject itemImage;
    [SerializeField] GameObject totalText;

    [SerializeField] ItemList itemInfo;

    //WILL NEED MORE IN THE FUTURE
    public void LoadItemInfo(ItemList itemInfo) {
        this.itemInfo = itemInfo;
        total = itemInfo.GetTotal();
        totalText.GetComponent<TMP_Text>().text = total.ToString();

    }

    public void LoadItemInfo(Sprite itemSprite, int itemTotal) {
        sprite = itemSprite;
        total = itemTotal;

        itemImage.GetComponent<Image>().sprite = itemSprite;
        totalText.GetComponent<TMP_Text>().text = itemTotal.ToString();

    }

}
