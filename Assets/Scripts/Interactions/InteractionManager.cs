using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private IInteractable interactAction;

    public void Awake() {
        //interactAction = this.gameObject.GetComponent(typeof(IInteractable)) as IInteractable;
    }

    public void StartInteraction() {
        interactAction.StartInteraction();
    }

    public void EndInteraction () {
        interactAction.EndInteraction();
    }
}
