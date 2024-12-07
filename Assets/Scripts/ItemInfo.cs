using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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


    public bool isDragged = false;
    public bool isUsed = false;

    [SerializeField] private RectTransform targetUIElement; // Reference to the UI element's RectTransform


    void Update() {
        Vector2 localMousePosition = targetUIElement.InverseTransformPoint(Input.mousePosition);
        if (targetUIElement.rect.Contains(localMousePosition)) {
            ShowTooltip();
        } else {
            HideTooltip();
        }
    }

    private void ShowTooltip() {
        menu.TurnOnToolTip(this.gameObject);
    }

    private void HideTooltip() {
        menu.TurnOffToolTip(this.gameObject);
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
        this.menu = menu.GetComponent<CraftingMenuManager>();
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
        if(isUsed) {
            menu.addItemInven(this.gameObject);
        } else {
            menu.addItemCrafting(this.gameObject);
        }
    }

    /*
void Update() {
    if (isDragged) {
        FollowMouse();
    }
}

public void OnPointerClick(PointerEventData eventData) {
    if (isDragged) {

    } else {
        if(itemInfo.GetTotal() > 1) {
            GameObject item = Instantiate(this.gameObject);
            item.GetComponent<ItemInfo>().itemInfo.SetTotal(1);
            item.transform.parent = this.transform.parent.transform.parent.transform.parent;
            item.GetComponent<ItemInfo>().isDragged = true;
            itemInfo.SetTotal(itemInfo.GetTotal()-1);
            total = itemInfo.GetTotal();
            totalText.GetComponent<TMP_Text>().text = total.ToString();

        } else {
            this.transform.parent = this.transform.parent.transform.parent.transform.parent;
            isDragged = true;
        }
    }
}
private void FollowMouse() {
    transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
} */
}
