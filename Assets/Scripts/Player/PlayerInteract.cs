using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    [SerializeField] private PlayerActions playerActions;

    [SerializeField] private GameObject interactObject = null;
    [SerializeField] private bool isInteracting = false;
    [SerializeField] private bool inMenu = false;


    [SerializeField] private Canvas inventory;
    [SerializeField] private Canvas menu;

    public bool isDialogue = false;
    public bool isAdvancing = false;

    private void Awake() {
        playerActions = new PlayerActions();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Interact") {
            interactObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Interact") {
            interactObject = null;
        }
    }

    private void Update() {
        if (!isDialogue) {
            if(!inMenu) {
                CheckInteract();
                CheckInventory();
            }
            CheckMenu();
        } else {
            CheckDialogue();
        }
    }

    private void CheckInteract() {
        bool actionPressed = playerActions.Actions.Interact.WasReleasedThisFrame();
        if(actionPressed && !isInteracting && interactObject != null) {
                isInteracting = true;
                interactObject.GetComponent<InteractionManager>().StartInteraction();
                return;
        }
        if (actionPressed && isInteracting && interactObject != null) {
                interactObject.GetComponent<InteractionManager>().EndInteraction();
                isInteracting = false;
                return;
        }
    }

    public void CheckInventory() {
        bool actionPressed = playerActions.Actions.Inventory.WasReleasedThisFrame();
        if(actionPressed && inventory.isActiveAndEnabled) {
            inventory.GetComponent<InventoryCanvas>().RemoveAllItems();
            inventory.enabled = false;
            return;
        } else if (actionPressed && !inventory.isActiveAndEnabled){
            inventory.GetComponent<InventoryCanvas>().PopulateItems();
            inventory.enabled = true;
            return;
        }
    }

    public void CheckMenu() {
        bool actionPressed = playerActions.Actions.Menu.WasReleasedThisFrame();
        if (actionPressed && menu.isActiveAndEnabled) {
            inMenu = false;
            menu.enabled = false;
            return;
        } else if (actionPressed && !menu.isActiveAndEnabled) {
            inMenu = true;
            menu.enabled = true;
            return;
        }
    }

    private void CheckDialogue() {
        bool actionPressed = playerActions.Actions.Interact.WasReleasedThisFrame();
        if (actionPressed) {
            isAdvancing = true;
            return;
        }
    }

    public bool GetDialogue() {
        return isAdvancing;
    }

    public void SetDialogue(bool ad) {
        isDialogue = ad;
    }

    public bool GetAdvancing() {
        return isAdvancing;
    }

    public void SetAdvancing(bool ad) {
        isAdvancing = ad;
    }

    private void OnEnable() {
        playerActions.Actions.Enable();
    }

    private void OnDisable() {
        playerActions.Actions.Disable();
    }
}
