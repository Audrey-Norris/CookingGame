using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExpeditionsMenu : MonoBehaviour, IInteractable
{
    [SerializeField] Canvas questCanvas;

    public void EndInteraction() {
        questCanvas.enabled = false;
    }

    public void StartInteraction() {
        questCanvas.enabled = true;
        questCanvas.gameObject.GetComponent<ExpeditionManager>().SetupExpeditions();
    }
}
