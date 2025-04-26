using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{

    public List<Quests> allQuests = new List<Quests>();

    public List<Quests> currentQuests = new List<Quests>();

    [SerializeField] private Quests activeQuest;
    [SerializeField] public GameObject questNPC;

    [SerializeField] private RenownManager renownManager;

    public void SetActiveQuest(Quests quest) {
        activeQuest = quest;
    }

    public Quests GetActiveQuest() {
        return activeQuest;
    }

    public void QuestChecker(Food item) {
        if(ConfirmQuest(activeQuest, item)) {
            questNPC.GetComponent<NPCManager>().NPCReaction(true);
            renownManager.UpdateRenown(activeQuest.faction);
        } else {
            questNPC.GetComponent<NPCManager>().NPCReaction(false);
        }
    }

    public bool ConfirmQuest(Quests quest, Food item) {
        bool questComplete = true;

        for (int i = 0; i < quest.flavorList.Length; i++) {
            if (item.flavorList[i].total < quest.flavorList[i].total) {
                Debug.Log("FALSE " + quest.flavorList[i].total + " " + item.flavorList[i].total);
                questComplete = false;
            }
        }

        return questComplete;
    }

}
