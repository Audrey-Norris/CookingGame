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
            CheckInteract();
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
