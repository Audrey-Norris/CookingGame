using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecipeInfo : MonoBehaviour, IPointerClickHandler 
{
    [SerializeField] Sprite sprite;

    [SerializeField] GameObject itemImage;
    [SerializeField] GameObject recipeName;

    public Recipe recipe;

    [SerializeField] CraftingMenuManager menu;
    [SerializeField] InventoryCanvas inventory;

    public bool isDragged = false;
    public bool isUsed = false;

    [SerializeField] private RectTransform targetUIElement; // Reference to the UI element's RectTransform

    public void UpdateItemInfo(Recipe recipe) {
        this.recipe = recipe;
        recipeName.GetComponent<TMP_Text>().text = recipe.Name.ToString();
        targetUIElement = this.gameObject.GetComponent<RectTransform>();
    }

    //WILL NEED MORE IN THE FUTURE
    public void LoadItemInfo(Recipe recipe, GameObject menu) {
        this.recipe = recipe;
        recipeName.GetComponent<TMP_Text>().text = recipe.Name.ToString();
        if (menu.GetComponent<CraftingMenuManager>()) {
            this.menu = menu.GetComponent<CraftingMenuManager>();
        } else {
            this.inventory = menu.GetComponent<InventoryCanvas>();
        }
        targetUIElement = this.gameObject.GetComponent<RectTransform>();
    }

    public void LoadItemInfo(Sprite itemSprite, int itemTotal) {
        sprite = itemSprite;
        itemImage.GetComponent<Image>().sprite = itemSprite;
        recipeName.GetComponent<TMP_Text>().text = recipe.Name.ToString();
        targetUIElement = this.gameObject.GetComponent<RectTransform>();

    }

    public void SetActive() {

    }

    public void SetInactive() {

    }

    public void OnPointerClick(PointerEventData eventData) {
        if (menu) {
            menu.setCurrentRecipe(recipe);
        }

    }
}
