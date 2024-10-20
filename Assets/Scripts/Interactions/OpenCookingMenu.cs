using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenCookingMenu : MonoBehaviour, IInteractable {

    [SerializeField] Canvas cookingCanvas;

    public void EndInteraction() {
        cookingCanvas.transform.gameObject.GetComponent<CraftingMenuManager>().RemoveAllItems();
        cookingCanvas.enabled = false;
    }

    public void StartInteraction() {
        cookingCanvas.transform.gameObject.GetComponent<CraftingMenuManager>().PopulateItems();
        cookingCanvas.enabled = true;
    }
}
