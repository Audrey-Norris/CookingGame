using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    [SerializeField] private PlayerActions playerActions;

    [SerializeField] private GameObject interactObject = null;
    [SerializeField] private bool isInteracting = false;

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
            isInteracting = false;
            interactObject.GetComponent<InteractionManager>().EndInteraction();
            interactObject = null;
        }
    }

    private void Update() {
        if(playerActions.Actions.Interact.ReadValue<float>() > 0 && !isInteracting && interactObject!= null) {
            isInteracting = true;
            interactObject.GetComponent<InteractionManager>().StartInteraction();
        }
    }

    private void OnEnable() {
        playerActions.Actions.Enable();
    }

    private void OnDisable() {
        playerActions.Actions.Disable();
    }
}
