using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNpcInteract : MonoBehaviour, IInteractable {

    [SerializeField] ItemList questItem;

    public void EndInteraction() {
        
    }

    public void StartInteraction() {
        GameObject player = GameObject.Find("Player");
        if (player.GetComponent<InventoryManager>().DoesItemExist(questItem)) {
            player.GetComponent<InventoryManager>().ReduceItem(questItem.item);
        }
    }
}
