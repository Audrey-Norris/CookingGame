using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour {

    [SerializeField] Sprite sprite;
    [SerializeField] int total;
    [SerializeField] GameObject itemImage;
    [SerializeField] GameObject totalText;

    public ItemList itemInfo;

    [SerializeField] public bool isDragged = false;

    [SerializeField] private GameObject menu;

    public void UpdateItemInfo(ItemList itemInfo) {
        this.itemInfo = itemInfo;
        total = itemInfo.GetTotal();
        totalText.GetComponent<TMP_Text>().text = total.ToString();
    }

    public void LoadItemInfo(ItemList itemInfo, GameObject menu) {
        this.itemInfo = itemInfo;
        total = itemInfo.GetTotal();
        sprite = itemInfo.item.sprite;
        itemImage.GetComponent<Image>().sprite = sprite;
        totalText.GetComponent<TMP_Text>().text = total.ToString();
        this.menu = menu;
    }

    public void MoveLocations() {
        if(menu.GetComponent<SpiceManager>()) {
            menu.GetComponent<SpiceManager>().AddSpice(this.gameObject);
        }
    }

    public void SelectQuestItem() {
        if (menu.GetComponent<InventoryCanvas>()) {
            menu.GetComponent<SelectQuestItem>().SetQuestItem(this.gameObject);
        }
    }

    public void ShowInfo() {
        if(menu.GetComponent<InventoryCanvas>()) {
            menu.GetComponent<InventoryCanvas>().ShowItem();
        }
    }

    public GameObject GetMenu () {
        return menu;
    }
}
