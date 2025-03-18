using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenCookingMenu : MonoBehaviour, IInteractable 
{

    [SerializeField] Canvas cookingCanvas;

    public void EndInteraction() {
        //cookingCanvas.transform.gameObject.GetComponent<RecipeListManager>().RemoveAllItems();
        //cookingCanvas.transform.gameObject.GetComponent<RecipeListManager>().RemoveAllRecipes();
        cookingCanvas.enabled = false;
    }

    public void StartInteraction() {
        cookingCanvas.transform.gameObject.GetComponent<RecipeListManager>().PopulateRecipes();
        cookingCanvas.enabled = true;
    }
}
