using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCookingMenu : MonoBehaviour, IInteractable {

    [SerializeField] Canvas cookingCanvas;

    public void EndInteraction() {
        cookingCanvas.enabled = false;
    }

    public void StartInteraction() {
        cookingCanvas.enabled = true;
    }
}
