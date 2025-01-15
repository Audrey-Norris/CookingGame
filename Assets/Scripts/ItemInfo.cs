using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour, IPointerClickHandler {
    [SerializeField] Sprite sprite;
    [SerializeField] int total;

    [SerializeField] GameObject itemImage;
    [SerializeField] GameObject totalText;

    public ItemList itemInfo;

    [SerializeField] CraftingMenuManager menu;
    [SerializeField] InventoryCanvas inventory;

    public bool isDragged = false;
    public bool isUsed = false;

    [SerializeField] private RectTransform targetUIElement; // Reference to the UI element's RectTransform

    [SerializeField] public bool toolTipActive;

    void Update() {
        Vector2 localMousePosition = targetUIElement.InverseTransformPoint(Input.mousePosition);
        if (targetUIElement.rect.Contains(localMousePosition)) {
            ShowTooltip();
        } else if (toolTipActive) {
            HideTooltip();
        }
    }

    private void ShowTooltip() {
        toolTipActive = true;
        if(menu) {
            menu.TurnOnToolTip(this.gameObject);
        } else {
            Debug.Log("Running!");
            inventory.TurnOnToolTip(this.gameObject);
        }
    }

    private void HideTooltip() {
        toolTipActive = false;
        if (menu) {
            menu.TurnOffToolTip(this.gameObject);
        } else {
            inventory.TurnOffToolTip(this.gameObject);
        }
    }

    public void UpdateItemInfo(ItemList itemInfo) {
        this.itemInfo = itemInfo;
        total = itemInfo.GetTotal();
        totalText.GetComponent<TMP_Text>().text = total.ToString();
        targetUIElement = this.gameObject.GetComponent<RectTransform>();
    }

    //WILL NEED MORE IN THE FUTURE
    public void LoadItemInfo(ItemList itemInfo, GameObject menu) {
        this.itemInfo = itemInfo;
        total = itemInfo.GetTotal();
        totalText.GetComponent<TMP_Text>().text = total.ToString();
        if(menu.GetComponent<CraftingMenuManager>()) {
            this.menu = menu.GetComponent<CraftingMenuManager>();
        } else {
            this.inventory = menu.GetComponent<InventoryCanvas>();
        }
        targetUIElement = this.gameObject.GetComponent<RectTransform>();
    }

    public void LoadItemInfo(Sprite itemSprite, int itemTotal) {
        sprite = itemSprite;
        total = itemTotal;

        itemImage.GetComponent<Image>().sprite = itemSprite;
        totalText.GetComponent<TMP_Text>().text = itemTotal.ToString();
        targetUIElement = this.gameObject.GetComponent<RectTransform>();

    }

    public void OnPointerClick(PointerEventData eventData) { 
        if(menu) {
            if (isUsed) {
                menu.addItemInven(this.gameObject);
            } else {
                menu.addItemCrafting(this.gameObject);
            }
        }

    }
}
