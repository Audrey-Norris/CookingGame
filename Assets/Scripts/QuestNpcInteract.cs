using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNpcInteract : MonoBehaviour, IInteractable {


    [SerializeField] Quests npcQuest;
    [SerializeField] TownStatusManager town;
    
    public void EndInteraction() {
        
    }

    public void StartInteraction() {
        GameObject player = GameObject.Find("Player");
        if(ConfirmQuest(npcQuest, player)) {
            town.AddBuilding(npcQuest.buildingReward);
            GameObject.Find("SaveManager").GetComponent<CharStats>().SetQuestCompleted(npcQuest.questName);
        } else {
            Debug.Log("You have not completed the quest!");
        }
    }

    public bool ConfirmQuest(Quests quest, GameObject player) {
        bool questComplete = true;
        ItemList[] items = player.GetComponent<InventoryManager>().GetAllItems();
        foreach(ItemList item in quest.itemsNeeded) {
            for(int i = 0; i < items.Length; i++) {
                if (items[i].item == item.item && items[i].total >= item.total) {
                    questComplete = true;
                    break;
                } else {
                    questComplete = false;
                }
            }
            if (!questComplete) {
                return false;
            }
        }
        return true;
    }
}
