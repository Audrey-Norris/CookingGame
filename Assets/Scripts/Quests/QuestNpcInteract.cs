using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class QuestNpcInteract : MonoBehaviour, IInteractable {


    [SerializeField] private Quests npcQuest;
    [SerializeField] private TownStatusManager town;

    [SerializeField] private QuestsManager quests;

    public void EndInteraction() {
        GameObject inventory = GameObject.Find("InventoryCanvas");
        inventory.GetComponent<Canvas>().enabled = false;

        GameObject.Find("MainCamera").GetComponent<CameraMovement>().LockMouse(true);

    }

    public void StartInteraction() { // Change this to open special inventory UI to select a meal to give to client
        GameObject player = GameObject.Find("Player");
        GameObject inventory = GameObject.Find("InventoryCanvas");
        inventory.GetComponent<InventoryCanvas>().PopulateItems();
        quests = GameObject.Find("SaveManager").GetComponent<QuestsManager>();
        quests.questNPC = this.gameObject;
        npcQuest = quests.GetActiveQuest();
        inventory.GetComponent<Canvas>().enabled = true;

        GameObject.Find("MainCamera").GetComponent<CameraMovement>().LockMouse(false);

    }
}
