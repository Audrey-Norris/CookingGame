using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecipeInfo : MonoBehaviour
{
    [SerializeField] Sprite sprite;

    [SerializeField] GameObject itemImage;
    [SerializeField] GameObject recipeName;

    public Recipe recipe;

    [SerializeField] RecipeListManager menu;
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
    public void LoadRecipeInfo(Recipe recipe, GameObject menu) {
        this.recipe = recipe;
        recipeName.GetComponent<TMP_Text>().text = recipe.Name.ToString();
        sprite = recipe.craftedItem.sprite;
        if (menu.GetComponent<RecipeListManager>()) {
            this.menu = menu.GetComponent<RecipeListManager>();
        } else {
            this.inventory = menu.GetComponent<InventoryCanvas>();
        }
        targetUIElement = this.gameObject.GetComponent<RectTransform>();
    }

    public void SetInfo() {
        GameObject.Find("CookingMenu").GetComponent<RecipeListManager>().SetCurrentRecipe(recipe);
    }

}
