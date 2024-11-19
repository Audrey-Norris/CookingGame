using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExpeditionsMenu : MonoBehaviour, IInteractable
{
    [SerializeField] Canvas questCanvas;

    [SerializeField] ItemList tomatos;
    [SerializeField] ItemList milk;

    public void EndInteraction() {
        //questCanvas.transform.gameObject.GetComponent<>().RemoveAllItems();
        //questCanvas.enabled = false;
    }

    public void StartInteraction() {
        //questCanvas.transform.gameObject.GetComponent<>().PopulateItems();
        //questCanvas.enabled = true;
        Debug.Log("Activating!");
        GameObject player = GameObject.Find("Player");
        player.GetComponent<InventoryManager>().AddItem(tomatos);
        player.GetComponent<InventoryManager>().AddItem(milk);
    }
}
